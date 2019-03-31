using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    /// <summary>
    /// Contains the logic for simulation of moisture change.
    /// </summary>
    public class MoistureModel
    {
        /// <summary>
        /// Reference to TemperatureModel.
        /// </summary>
        private TemperatureModel m_temperatureModel = null;

        /// <summary>
        /// Index of selected moisture production setting.
        /// </summary>
        public int MoistureProductionSelection { get; set; } = 0;

        /// <summary>
        /// Index of selected moisture removal setting.
        /// </summary>
        public int MoistureRemovalSelection { get; set; } = 0;

        /// <summary>
        /// Moisture production settings. Determines the amount of water that moves into the air per half hour.
        /// </summary>
        private readonly float[] m_moistureProduction = new float[3] { 0.1f, 0.2f, 0.3f };

        /// <summary>
        /// Moisture removal settings. Determines the amount of water removed from the air.
        /// </summary>
        private readonly float[] m_moistureRemoval = new float[3] { 0.1f, 0.2f, 0.3f };

        /// <summary>
        /// Moistoure production duration settings. Determines the length of time (in ticks) moisture is being produced.
        /// </summary>
        private readonly int[] m_moistureProductionLength = new int[] { 6, 10, 14 };

        /// <summary>
        /// The current amount (in litres) of water in the air.
        /// </summary>
        private float m_moistureInAir = 1f;

        /// <summary>
        /// The percentage of total possible litres of water in air based on temperature.
        /// </summary>
        private int m_airSaturation = 50;

        /// <summary>
        /// The percentage of total possible litres of water in wall based on temperature.
        /// </summary>
        private float m_wallSaturation = 10f;

        /// <summary>
        /// Instance of the air saturation table.
        /// </summary>
        private AirSaturationTable m_airSaturationTable = new AirSaturationTable();

        /// <summary>
        /// Contains the impact on wall saturation per half hour based upon the air saturation
        /// </summary>
        private readonly Dictionary<int, int> m_wallSaturationDictionary = new Dictionary<int, int>() 
        {
            [50] = -4,
            [60] = -2,
            [70] = 2,
            [80] = 4,
            [90] = 6,
            [100] = 8
        };

        /// <summary>
        /// Constructor for MoistureModel. Initialises the TemperatureModel reference.
        /// </summary>
        /// <param name="_tempModel"></param>
        public MoistureModel(TemperatureModel _tempModel)
        {
            m_temperatureModel = _tempModel;
        }

        /// <summary>
        /// Checks the current tick and updates the moisture values based on the selection settings accordingly.
        /// </summary>
        /// <param name="_currentTick">The current tick of the simulation.</param>
        public void AdjustMoisture(int _currentTick)
        {
            /// If currentTick is within moisture production period.
            if ((_currentTick >= 16 && _currentTick < (16 + m_moistureProductionLength[MoistureProductionSelection])) || (_currentTick >= 30 && _currentTick < (30 + m_moistureProductionLength[MoistureProductionSelection])))
            {
                /// Increase moisture.
                m_moistureInAir += m_moistureProduction[MoistureProductionSelection]; 
            }
            else
            {
                /// Decrease moisture.
                m_moistureInAir -= m_moistureRemoval[MoistureRemovalSelection]; 
            }

            /// Limit max and min moisture in air.
            if (m_moistureInAir > 5) 
            {
                m_moistureInAir = 5f;
            }
            else if (m_moistureInAir < 1) 
            {
                m_moistureInAir = 1f;
            }

            /// Get saturation value using temperature and air moisture.
            m_airSaturation = m_airSaturationTable.GetValue(RoundToNearestEven(m_temperatureModel.AirTemperature), Mathf.RoundToInt(m_moistureInAir));

            /// Limit minimum wall saturation
            if ((m_wallSaturation += m_wallSaturationDictionary[m_airSaturation]) < 0)
            {
                m_wallSaturation = 0f;
            }
            else if ((m_wallSaturation += m_wallSaturationDictionary[m_airSaturation]) > 100)
            {
                m_wallSaturation = 100f;
            }
            else
            {
                /// Get impact using air saturation and add it to wall saturation.
                m_wallSaturation += m_wallSaturationDictionary[m_airSaturation];
            }

            /// Debug messages.
            Debug.Log("MoistureProductionSelection: " + MoistureProductionSelection + " MoistureRemovalSelection: " + MoistureRemovalSelection);

            Debug.Log("moistureProductionLength: " + m_moistureProductionLength[MoistureProductionSelection] + " moistureRemoval: " + m_moistureRemoval[MoistureRemovalSelection]);

            Debug.Log("Moisture in air: " + m_moistureInAir +
                "       Air saturation: " + m_airSaturation +
                "       Wall saturation: " + m_wallSaturation);
        }

        /// <summary>
        /// Rounds a float to the nearest even number. Used to produce an even number to access correct value from AirSaturationTable.
        /// </summary>
        /// <param name="_num">The number to be rounded.</param>
        /// <returns>An even integer.</returns>
        private int RoundToNearestEven(float _num)
        {
            double _result = System.Math.Round(_num / 2, System.MidpointRounding.AwayFromZero) * 2;

            return (int)_result;
        }

        /// <summary>
        /// Returns the selected moisture production setting.
        /// </summary>
        public int SelectedMoistureProductionSetting
        {
            get
            {
                return m_moistureProductionLength[MoistureProductionSelection];
            }
        }
    
        /// <summary>
        /// Returns the selected moisture removal setting.
        /// </summary>
        public float SelectedMoistureRemovalSetting
        {
            get
            {
                return m_moistureRemoval[MoistureRemovalSelection];
            }
        }

        /// <summary>
        /// Resets simulation variables to default values
        /// </summary>
        public void Reset()
        {
            m_moistureInAir = 1f;
            m_airSaturation = 50;
            m_wallSaturation = 10f;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    public class MoistureModel
    {
        /// <summary>
        /// Reference to TemperatureModel
        /// </summary>
        private TemperatureModel m_temperatureModel = null;

        /// <summary>
        /// User selections
        /// </summary>
        public int MoistureProductionSelection { get; set; } = 0;
        public int MoistureRemovalSelection { get; set; } = 0;

        /// <summary>
        /// Data Arrays
        /// </summary>
        private readonly float[] m_moistureProduction = new float[3] { 0.1f, 0.2f, 0.3f }; // the amount of water that moves into the air per half hour
        private readonly float[] m_moistureRemoval = new float[3] { 0.1f, 0.2f, 0.3f }; // the amount of water removed from the air
        private readonly int[] m_moistureProductionLength = new int[] { 6, 10, 14 }; // the length of time moisure is being produced in ticks

        /// <summary>
        /// Moisture Variables
        /// </summary>
        private float m_moistureInAir = 1f; // the amount of water in the air in litres
        private int m_airSaturation = 50; // a percentage of total possible litres of water in air based on temperature
        private float m_wallSaturation; // a percentage of total possible litres of water in wall based on temperature

        /// <summary>
        /// Data access containers
        /// </summary>
        private AirSaturationTable m_airSaturationTable = new AirSaturationTable();
        private readonly Dictionary<int, int> m_wallSaturationDictionary = new Dictionary<int, int>() // contains the impact on wall saturation per half hour based upon the air saturation
        {
            [50] = -4,
            [60] = -2,
            [70] = 2,
            [80] = 4,
            [90] = 6,
            [100] = 8
        };

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="_tempModel"></param>
        public MoistureModel(TemperatureModel _tempModel)
        {
            m_temperatureModel = _tempModel;
        }

        /// <summary>
        /// Checks the current tick and updates the moisture values based on the selection settings accordingly.
        /// </summary>
        /// <param name="_currentTick">The current tick of the simulation</param>
        public void AdjustMoisture(int _currentTick)
        {
            // if currentTick is within moisture production period
            if ((_currentTick >= 16 && _currentTick < (16 + m_moistureProductionLength[MoistureProductionSelection])) || (_currentTick >= 30 && _currentTick < (30 + m_moistureProductionLength[MoistureProductionSelection])))
            {
                m_moistureInAir += m_moistureProduction[MoistureProductionSelection]; // increase moisture
            }
            else
            {
                m_moistureInAir -= m_moistureRemoval[MoistureRemovalSelection]; // decrease moisture
            }

            // moisture limiting
            if (m_moistureInAir > 5) // limit max moisture
            {
                m_moistureInAir = 5f;
            }
            else if (m_moistureInAir < 1) // limit min moisture
            {
                m_moistureInAir = 1f;
            }

            m_airSaturation = m_airSaturationTable.GetValue(RoundToNearestEven(m_temperatureModel.AirTemperature), Mathf.RoundToInt(m_moistureInAir)); // get saturation value using temperature and air moisture

            m_wallSaturation += m_wallSaturationDictionary[m_airSaturation]; // get impact using air saturation and add it to wall saturation 

            /// Debug messages
            Debug.Log("MoistureProductionSelection: " + MoistureProductionSelection + " MoistureRemovalSelection: " + MoistureRemovalSelection);
            Debug.Log("moistureProductionLength: " + m_moistureProductionLength[MoistureProductionSelection] + " moistureRemoval: " + m_moistureRemoval[MoistureRemovalSelection]);

            Debug.Log("Moisture in air: " + m_moistureInAir +
                "       Air saturation: " + m_airSaturation +
                "       Wall saturation: " + m_wallSaturation);
        }

        /// <summary>
        /// Rounds a float to the nearest even number
        /// </summary>
        /// <param name="_num">The number to be rounded</param>
        /// <returns>An even integer</returns>
        private int RoundToNearestEven(float _num) // - need this because temperature in dictionary is multiples of two
        {
            double _result = System.Math.Round(_num / 2, System.MidpointRounding.AwayFromZero) * 2;
            return (int)_result;
        }

        public int SelectedMoistureProductionSetting
        {
            get
            {
                return m_moistureProductionLength[MoistureProductionSelection];
            }
        }

        public float SelectedMoistureRemovalSetting
        {
            get
            {
                return m_moistureRemoval[MoistureRemovalSelection];
            }
        }
    }
}
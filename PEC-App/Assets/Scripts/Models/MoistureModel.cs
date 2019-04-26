using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Contains the logic for simulation of moisture change.
/// </summary>
public class MoistureModel : IAdjustable
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
    private readonly float[] m_moistureProduction = new float[3] { 0.1f, 0.15f, 0.2f };

    /// <summary>
    /// Moisture removal settings. Determines the amount of water removed from the air.
    /// </summary>
    private readonly float[] m_moistureRemoval = new float[3] { 0.05f, 0.1f, 0.15f };

    /// <summary>
    /// Moistoure production duration settings. Determines the length of time (in ticks) moisture is being produced.
    /// </summary>
    private readonly int[] m_moistureProductionLength = new int[] { 6, 7, 8 };

    /// <summary>
    /// The current amount (in litres) of water in the air.
    /// </summary>
    private float m_moistureInAir = 1f;

    /// <summary>
    /// The percentage of total possible litres of water in air based on temperature.
    /// </summary>
    public int AirSaturation { get; private set; } = 50;

    /// <summary>
    /// The percentage of total possible litres of water in wall based on temperature.
    /// </summary>
    public int WallSaturation { get; private set; } = 0;

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
        [70] = 1,
        [80] = 1,
        [90] = 2,
        [100] = 3
    };

    /// <summary>
    /// Delegate for sending wall saturation.
    /// </summary>
    /// <param name="_dampValue">The wall saturation converted to a value between 0-1</param>
    public delegate void SendWallSaturation(float _dampValue);

    /// <summary>
    /// Event for triggering delegate.
    /// </summary>
    public static event SendWallSaturation OnSendWallSaturation;


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
    public void AdjustVariables(int _currentTick)
    {
        /// If currentTick is within moisture production period.
        if ((_currentTick >= 16 && _currentTick < (16 + m_moistureProductionLength[MoistureProductionSelection])) || (_currentTick >= 30 && _currentTick < (30 + m_moistureProductionLength[MoistureProductionSelection])))
        {
            /// Increase moisture.
            m_moistureInAir += m_moistureProduction[MoistureProductionSelection];
            EventManager.Instance.RaiseMoistureProductionOnEvent();
        }
        else
        {
            /// Decrease moisture.
            m_moistureInAir -= m_moistureRemoval[MoistureRemovalSelection];
            EventManager.Instance.RaiseMoistureProductionOffEvent();
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
        AirSaturation = m_airSaturationTable.GetValue(RoundToNearestEven(m_temperatureModel.AirTemperature), Mathf.RoundToInt(m_moistureInAir));

        if (AirSaturation >= 70)
        {
            EventManager.Instance.RaiseCondensationOnEvent();
        }
        else
        {
            EventManager.Instance.RaiseCondensationOffEvent();
        }

        /// Limit minimum wall saturation
        if ((WallSaturation + m_wallSaturationDictionary[AirSaturation]) < 0)
        {
            WallSaturation = 0;
        }
        /// Limit maxiumum wall saturation
        else if ((WallSaturation + m_wallSaturationDictionary[AirSaturation]) > 100)
        {
            WallSaturation = 100;
        }
        else
        {
            /// Get impact using air saturation and add it to wall saturation.
            WallSaturation += m_wallSaturationDictionary[AirSaturation];
        }

        /// Trigger event to send out wall saturation to listener
        OnSendWallSaturation?.Invoke((float)WallSaturation / 100);

        /// Debug messages.
        Debug.Log("MoistureProductionSelection: " + MoistureProductionSelection + " MoistureRemovalSelection: " + MoistureRemovalSelection);

        Debug.Log("moistureProductionLength: " + m_moistureProductionLength[MoistureProductionSelection] + " moistureRemoval: " + m_moistureRemoval[MoistureRemovalSelection]);

        Debug.Log("Moisture in air: " + m_moistureInAir +
            "       Air saturation: " + AirSaturation +
            "       Wall saturation: " + WallSaturation);
    }

    /// <summary>
    /// Resets simulation variables to default values
    /// </summary>
    public void ResetVariables()
    {
        m_moistureInAir = 1f;
        AirSaturation = 50;
        WallSaturation = 0;
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
}
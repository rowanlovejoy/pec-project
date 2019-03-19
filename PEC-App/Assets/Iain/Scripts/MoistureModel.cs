using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoistureModel
{
    public MoistureModel(TemperatureModel tempModel)
    {
        temperatureModel = tempModel;
    }

    private TemperatureModel temperatureModel;

    // User selections
    public int MoistureProductionSelection { get; set; } = 2;
    public int MoistureRemovalSelection { get; set; } = 1;

    // Data Arrays
    float[] moistureProduction = new float[3] { 0.1f, 0.2f, 0.3f }; // the amount of water that moves into the air per half hour
    float[] moistureRemoval = new float[3] { 0.1f, 0.2f, 0.3f }; // the amount of water removed from the air
    int[] moistureProductionLength = new int[] { 6, 12, 18 }; // the length of time moisure is being produced in ticks

    // Moisture Variables
    private float m_moistureInAir = 1f; // the amount of water in the air in litres
    private int m_airSaturation = 50; // a percentage of total possible litres of water in air based on temperature
    private float m_wallSaturation; // a percentage of total possible litres of water in wall based on temperature

    private Dictionary<int, int> m_wallSaturationDictionary = new Dictionary<int, int>() // contains the impact on wall saturation per half hour based upon the air saturation
    {
        [50] = -4,
        [60] = -2,
        [70] = 2,
        [80] = 4,
        [90] = 6,
        [100] = 8
    };

    private AirSaturationTable airSaturationTable = new AirSaturationTable();


    public void AdjustMoisture(int currentTick)
    {
        // if currentTick is within moisture production period
        if ((currentTick >= 12 && currentTick < (12 + moistureProductionLength[MoistureProductionSelection])) || (currentTick >= 34 && currentTick < (34 + moistureProductionLength[MoistureProductionSelection])))
        {
            m_moistureInAir += moistureProduction[MoistureProductionSelection]; // increase moisture
        }
        else
        {
            m_moistureInAir -= moistureRemoval[MoistureRemovalSelection]; // decrease moisture
        }

        if (m_moistureInAir > 5) // limit max moisture
        {
            m_moistureInAir = 5f;
        }
        else if (m_moistureInAir < 1) // limit min moisture
        {
            m_moistureInAir = 1f;
        }

        m_airSaturation = airSaturationTable.GetValue(RoundToNearestEven(temperatureModel.AirTemperature), Mathf.RoundToInt(m_moistureInAir)); // get saturation value using temperature and air moisture

        m_wallSaturation += m_wallSaturationDictionary[m_airSaturation]; // get

        Debug.Log("Moisture in air: " + m_moistureInAir +
            "       Air saturation: " + m_airSaturation +
            "       Wall saturation: " + m_wallSaturation);
    }

    private int RoundToNearestEven(float num)
    {
        double result = System.Math.Round(num / 2, System.MidpointRounding.AwayFromZero) * 2;
        return (int)result;
        //return ((int)num - ((int)num % 2)); - this rounds down to nearest even
    }
}
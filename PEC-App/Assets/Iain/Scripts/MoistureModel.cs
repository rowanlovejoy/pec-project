using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoistureModel : MonoBehaviour
{
    public TemperatureModel temperatureModel;

    // User selections
    public int MoistureProductionSelection { get; set; }
    public int MoistureRemovalSelection { get; set; }

    // Data Arrays
    float[] moistureProduction = new float[3] { 0.1f, 0.2f, 0.3f }; // The amount of water that moves into the air per half hour
    float[] moistureRemoval = new float[3] { 0.1f, 0.2f, 0.3f }; // The amount of water removed from the air

    // Moisture Variables
    private float m_moistureInAir = 1f; // the amount of water in the air in litres
    private int m_airSaturation = 50; // a percentage of total possible litres of water in air based on temperature
    private float m_wallSaturation; // a percentage of total possible litres of water in wall based on temperature


    private Dictionary<int, int> m_wallSaturationDictionary = new Dictionary<int, int>() // a simple way to get the impact per half hour based upon the air saturation
    {
        [50] = -4,
        [60] = -2,
        [70] = 2,
        [80] = 4,
        [90] = 6,
        [100] = 8
    }; 

    private AirSaturationTable airSaturationTable;

    private void AdjustMoisture()
    {
        m_moistureInAir += (moistureProduction[MoistureProductionSelection] - moistureRemoval[MoistureRemovalSelection]);

        m_airSaturation = airSaturationTable.GetValue(RoundToNearestEven(temperatureModel.AirTemperature), Mathf.RoundToInt(m_moistureInAir));

        m_wallSaturation += m_wallSaturationDictionary[m_airSaturation];

        Debug.Log("Moisture in air: " + m_moistureInAir +
            "\nAir saturation: " + m_airSaturation +
            "\nWall saturation: " + m_wallSaturation);
    }

    private int RoundToNearestEven(float num)
    {
        double result = System.Math.Round(num / 2, System.MidpointRounding.AwayFromZero) * 2;
        return (int)result;
        //return ((int)num - ((int)num % 2)); - this rounds down to nearest even
    }
}

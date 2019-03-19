using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureModel : MonoBehaviour
{
    /// <summary>
    /// The current temperature of air inside the house in degrees
    /// </summary>
    public float AirTemperature { get; }

    // Heating Variables
    private bool m_activeHeatingPeriod = false; // true based on currentTick and heatingPeriod
    private bool m_heatingIsOn = false; // whether or not the heating is on based on activeHeatingPeriod, airTemp and thermostatSetting

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureModel : MonoBehaviour
{
    /// <summary>
    /// Heating Period selection made by user
    /// </summary>
    public int HeatingPeriodSelection { get; set; }

    /// <summary>
    /// Thermostat Setting selection made by user
    /// </summary>
    public int ThermostatSettingSelection { get; set; }

    private int[] m_heatingPeriod = new int[3] { 4, 6, 10 }; // How long heating is on for after coming on in ticks
    private int[] m_thermostatSetting = new int[3] { 18, 20, 22 }; // The cutoff point for the heating in degrees

    // Heating Variables
    private bool m_activeHeatingPeriod = false; // true based on currentTick and heatingPeriod
    private bool m_heatingIsOn = false; // whether or not the heating is on based on activeHeatingPeriod, airTemp and thermostatSetting
    private float m_airTemp = 18f; // the current temperature of air inside the house in degrees

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustHeating(int currentTick)
    {
        // if currentTick is within heating period
        if ((currentTick >= 12 && currentTick < (12 + m_heatingPeriod[HeatingPeriodSelection])) || (currentTick >= 34 && currentTick < (34 + m_heatingPeriod[HeatingPeriodSelection])))
        {
            m_activeHeatingPeriod = true;
        }
        else
        {
            m_activeHeatingPeriod = false;
        }

        // If activeHeatingPeriod is true and airTemp is less than thermostatSetting
        if (m_activeHeatingPeriod && (m_airTemp < m_thermostatSetting[ThermostatSettingSelection]))
        {
            m_heatingIsOn = true;
            m_airTemp += 1f;
        }
        else
        {
            m_heatingIsOn = false;
            if (m_airTemp - 0.2f < 14)
            {
                m_airTemp = 14f; // air temperature should not drop below 14
            }
            else
            {
                m_airTemp -= 0.2f;
            }
        }
    }
}

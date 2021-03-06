﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Contains the logic for simulation of temperature change.
/// </summary>
public class TemperatureModel : IAdjustable
{
    /// <summary>
    /// Index of selected heating period.
    /// </summary>
    public int HeatingPeriodSelection { get; set; } = 0;

    /// <summary>
    /// Index of selected thermostat setting.
    /// </summary>
    public int ThermostatSettingSelection { get; set; } = 0;

    /// <summary>
    /// The current temperature of air inside the house (degrees celsius).
    /// </summary>
    public float AirTemperature { get; private set; } = 14f;

    /// <summary>
    /// Heating period options. Determines how long heating is on for after coming on in ticks.
    /// </summary>
    private readonly int[] m_heatingPeriod = new int[3] { 4, 6, 10 };

    /// <summary>
    /// Thermostat setting options. 
    /// Values determine the temperature (in degress celsius) at which heating will be turned off.
    /// </summary>
    private readonly int[] m_thermostatSetting = new int[3] { 18, 20, 22 };

    /// <summary>
    /// Indicates if simulation is currently in a period of active heating. True if so; false otherwise. Based on the current simulation tick and whether it is in a period of active heating.
    /// </summary>
    private bool m_activeHeatingPeriod = false;

    /// <summary>
    /// Indicates if the heating is turned on. True if so; false otherwise. Based on whether simulation is in a period of active heating, current air temperature, and themostat setting.
    /// </summary>
    public bool HeatingIsOn { get; private set; } = false;

    /// <summary>
    /// Checks the current tick and updates the heating values based on the selection settings accordingly.
    /// </summary>
    /// <param name="currentTick">The current tick of the simulation</param>
    public void AdjustVariables(int _currentTick)
    {
        /// if currentTick is within heating period.
        if ((_currentTick >= 12 && _currentTick < (12 + m_heatingPeriod[HeatingPeriodSelection])) || (_currentTick >= 34 && _currentTick < (34 + m_heatingPeriod[HeatingPeriodSelection])))
        {
            m_activeHeatingPeriod = true;
        }
        else
        {
            m_activeHeatingPeriod = false;
        }

        /// If activeHeatingPeriod is true and airTemp is less than thermostatSetting.
        if (m_activeHeatingPeriod && (AirTemperature < m_thermostatSetting[ThermostatSettingSelection]))
        {
            HeatingIsOn = true;

            AirTemperature += 1f;

            EventManager.Instance.RaiseHeatingOnEvent();
            EventManager.Instance.RaiseLowTemperatureOffEvent();
        }
        else
        {
            HeatingIsOn = false;
            EventManager.Instance.RaiseHeatingOffEvent();

            if (AirTemperature - 0.2f < 14)
            {
                /// Air temperature should not drop below 14.
                AirTemperature = 14f;
                EventManager.Instance.RaiseLowTemperatureOnEvent();
            }
            else
            {
                AirTemperature -= 0.2f;
            }
        }

        /// Debug messages.
        Debug.Log("HeatingPeriodSelection: " + HeatingPeriodSelection + " ThermostatSettingSelection: " + ThermostatSettingSelection);

        Debug.Log("m_heatingPeriod: " + m_heatingPeriod[HeatingPeriodSelection] + " m_thermostatSetting: " + m_thermostatSetting[ThermostatSettingSelection]);

        Debug.Log("Active heating period: " + m_activeHeatingPeriod +
            "        Heating is on: " + HeatingIsOn +
            "        Air temperature: " + AirTemperature);
    }

    /// <summary>
    /// Resets simulation variables to default values
    /// </summary>
    public void ResetVariables()
    {
        AirTemperature = 14f;
        m_activeHeatingPeriod = false;
        HeatingIsOn = false;
    }

    /// <summary>
    /// Returns the currently selected thermostat setting.
    /// </summary>
    public int SelectedThermostatSetting
    {
        get
        {
            return m_thermostatSetting[ThermostatSettingSelection];
        }
    }

    /// <summary>
    /// Returns the currently selected heating period setting.
    /// </summary>
    public int SelectedHeatingPeriodSetting
    {
        get
        {
            return m_heatingPeriod[HeatingPeriodSelection];
        }
    }
}

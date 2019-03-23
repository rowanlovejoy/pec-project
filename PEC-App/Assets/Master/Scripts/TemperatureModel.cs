using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    public class TemperatureModel
    {
        // User selections
        public int HeatingPeriodSelection { get; set; } = 0;
        public int ThermostatSettingSelection { get; set; } = 0;

        /// <summary>
        /// The current temperature of air inside the house in degrees
        /// </summary>
        public float AirTemperature { get; private set; } = 18f;

        // Data Arrays
        private readonly int[] m_heatingPeriod = new int[3] { 4, 6, 10 }; // How long heating is on for after coming on in ticks
        private readonly int[] m_thermostatSetting = new int[3] { 18, 20, 22 }; // The cutoff point for the heating in degrees

        // Heating Variables
        private bool m_activeHeatingPeriod = false; // true based on currentTick and heatingPeriod
        private bool m_heatingIsOn = false; // whether or not the heating is on based on activeHeatingPeriod, airTemp and thermostatSetting

        /// <summary>
        /// Checks the current tick and updates the heating values based on the selection settings accordingly.
        /// </summary>
        /// <param name="_currentTick">The current tick of the simulation</param>
        public void AdjustHeating(int _currentTick)
        {
            // if currentTick is within heating period
            if ((_currentTick >= 12 && _currentTick < (12 + m_heatingPeriod[HeatingPeriodSelection])) || (_currentTick >= 34 && _currentTick < (34 + m_heatingPeriod[HeatingPeriodSelection])))
            {
                m_activeHeatingPeriod = true;
            }
            else
            {
                m_activeHeatingPeriod = false;
            }

            // If activeHeatingPeriod is true and airTemp is less than thermostatSetting
            if (m_activeHeatingPeriod && (AirTemperature < m_thermostatSetting[ThermostatSettingSelection]))
            {
                m_heatingIsOn = true;
                AirTemperature += 1f;
            }
            else
            {
                m_heatingIsOn = false;
                if (AirTemperature - 0.2f < 14)
                {
                    AirTemperature = 14f; // air temperature should not drop below 14
                }
                else
                {
                    AirTemperature -= 0.2f;
                }
            }

            /// Debug messages
            Debug.Log("HeatingPeriodSelection: " + HeatingPeriodSelection + " ThermostatSettingSelection: " + ThermostatSettingSelection);
            Debug.Log("m_heatingPeriod: " + m_heatingPeriod[HeatingPeriodSelection] + " m_thermostatSetting: " + m_thermostatSetting[ThermostatSettingSelection]);

            Debug.Log("Active heating period: " + m_activeHeatingPeriod +
                "        Heating is on: " + m_heatingIsOn +
                "        Air temperature: " + AirTemperature);
        }

        public int SelectedThermostatSetting
        {
            get
            {
                return m_thermostatSetting[ThermostatSettingSelection];
            }
        }
    }
}
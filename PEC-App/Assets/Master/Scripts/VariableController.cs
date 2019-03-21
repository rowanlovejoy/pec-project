using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    public class VariableController : MonoBehaviour
    {
        [SerializeField]
        private CoreAlgorithm m_coreAlgorithm = null;

        /// <summary>
        /// Sets the heating period selection in the temperature model. Used with a slider.
        /// </summary>
        /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
        public void UpdateHeatingPeriodSelection(float _value)
        {
            m_coreAlgorithm.TemperatureModel.HeatingPeriodSelection = (int)_value;
        }

        /// <summary>
        /// Sets the thermostat setting in the temperature model. Used with a slider.
        /// </summary>
        /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
        public void UpdateThermostatSelection(float _value)
        {
            m_coreAlgorithm.TemperatureModel.ThermostatSettingSelection = (int)_value;
        }

        /// <summary>
        /// Sets the moisture production setting in the moisture model. Used with a slider.
        /// </summary>
        /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
        public void UpdateMoistureProductionSelection(float _value)
        {
            m_coreAlgorithm.MoistureModel.MoistureProductionSelection = (int)_value;
        }

        /// <summary>
        /// Sets the moisture removal setting in the moisture model. Used with a slider.
        /// </summary>
        /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
        public void UpdateMoistureRemovalSelection(float _value)
        {
            m_coreAlgorithm.MoistureModel.MoistureRemovalSelection = (int)_value;
        }
    }
}
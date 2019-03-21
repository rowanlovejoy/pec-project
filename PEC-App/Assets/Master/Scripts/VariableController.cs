using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Master
{
    public class VariableController : MonoBehaviour
    {
        [SerializeField]
        private CoreAlgorithm m_coreAlgorithm = null;
        [SerializeField]
        private TextMeshProUGUI[] m_sliderValueDisplays = null;
        [SerializeField]
        private Slider[] m_sliders = null;

        private void Awake()
        {
            InitialiseSliderValueDisplays();
        }

        private void InitialiseSliderValueDisplays()
        {
            if (m_sliderValueDisplays.Length == m_sliders.Length)
            {
                for (int i = 0; i < m_sliderValueDisplays.Length; i++)
                {
                    if (m_sliderValueDisplays[i] != null && m_sliders[i] != null)
                    {
                        m_sliderValueDisplays[i].text = m_sliders[i].value.ToString();
                    }
                    else
                    {
                        Debug.Log("Error setting slider value displays; unequal number of sliders and value displays", gameObject);
                        break;
                    }
                }
            }
            else
            {
                Debug.Log("Error setting slider value displays; unequal number of sliders and value displays", gameObject);
            }
        }

        /// <summary>
        /// Sets the heating period selection in the temperature model. Used with a slider.
        /// </summary>
        /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
        public void UpdateHeatingPeriodSelection(float _value)
        {
            m_coreAlgorithm.TemperatureModel.HeatingPeriodSelection = (int)_value;
            m_sliderValueDisplays[0].text = _value.ToString();
        }

        /// <summary>
        /// Sets the thermostat setting in the temperature model. Used with a slider.
        /// </summary>
        /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
        public void UpdateThermostatSelection(float _value)
        {
            m_coreAlgorithm.TemperatureModel.ThermostatSettingSelection = (int)_value;
            m_sliderValueDisplays[1].text = _value.ToString();
        }

        /// <summary>
        /// Sets the moisture production setting in the moisture model. Used with a slider.
        /// </summary>
        /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
        public void UpdateMoistureProductionSelection(float _value)
        {
            m_coreAlgorithm.MoistureModel.MoistureProductionSelection = (int)_value;
            m_sliderValueDisplays[2].text = _value.ToString();
        }

        /// <summary>
        /// Sets the moisture removal setting in the moisture model. Used with a slider.
        /// </summary>
        /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
        public void UpdateMoistureRemovalSelection(float _value)
        {
            m_coreAlgorithm.MoistureModel.MoistureRemovalSelection = (int)_value;
            m_sliderValueDisplays[3].text = _value.ToString();
        }

        /// <summary>
        /// Starts the simulation upon button press
        /// </summary>
        public void StartSimulation()
        {
            m_coreAlgorithm.StartSimulation();
        }

        /// <summary>
        /// Stops the simulation upon button press
        /// </summary>
        public void StopSimulation()
        {
            m_coreAlgorithm.StopSimulation();
        }
    }
}
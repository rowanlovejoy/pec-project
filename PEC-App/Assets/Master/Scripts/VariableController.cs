using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Master
{
    public class VariableController : MonoBehaviour
    {
        /// <summary>
        /// Reference to CoreAlgorithm
        /// </summary>
        [SerializeField]
        private CoreAlgorithm m_coreAlgorithm = null;
        /// <summary>
        /// Reference to the container of the Simulation Display GUI
        /// </summary>
        [SerializeField]
        private GameObject m_simulationDisplayGUI = null;
        /// <summary>
        /// References to slider value labels
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI[] m_sliderValueDisplays = null;
        /// <summary>
        /// References to slider GUI elements
        /// </summary>
        [SerializeField]
        private Slider[] m_sliders = null;

        private void Awake()
        {
            InitialiseSliderValueDisplays();
        }

        /// <summary>
        /// Sets the values displayed for each slider to the sliders' current values
        /// </summary>
        private void InitialiseSliderValueDisplays()
        {
            if (m_sliderValueDisplays.Length == m_sliders.Length)
            {
                for (int i = 0; i < m_sliderValueDisplays.Length; i++)
                {
                    if (m_sliderValueDisplays[i] != null && m_sliders[i] != null)
                    {
                        m_sliderValueDisplays[i].text = "" + (m_sliders[i].value + 1);
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
            m_sliderValueDisplays[0].text = "" + (_value + 1);
        }

        /// <summary>
        /// Sets the thermostat setting in the temperature model. Used with a slider.
        /// </summary>
        /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
        public void UpdateThermostatSelection(float _value)
        {
            m_coreAlgorithm.TemperatureModel.ThermostatSettingSelection = (int)_value;
            m_sliderValueDisplays[1].text = "" + (_value + 1);
        }

        /// <summary>
        /// Sets the moisture production setting in the moisture model. Used with a slider.
        /// </summary>
        /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
        public void UpdateMoistureProductionSelection(float _value)
        {
            m_coreAlgorithm.MoistureModel.MoistureProductionSelection = (int)_value;
            m_sliderValueDisplays[2].text = "" + (_value + 1);
        }

        /// <summary>
        /// Sets the moisture removal setting in the moisture model. Used with a slider.
        /// </summary>
        /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
        public void UpdateMoistureRemovalSelection(float _value)
        {
            m_coreAlgorithm.MoistureModel.MoistureRemovalSelection = (int)_value;
            m_sliderValueDisplays[3].text = "" + (_value + 1);
        }

        /// <summary>
        /// Starts the simulation upon button press
        /// </summary>
        public void StartSimulation()
        {
            /// Starts the simulation if it is not ongoing
            m_coreAlgorithm.StartSimulation();
            /// Hides the Main Panel when the simulation starts
            gameObject.SetActive(false);
            /// Shows the Simulation Display GUI when the simulation starts
            m_simulationDisplayGUI.SetActive(true);
        }
    }
}
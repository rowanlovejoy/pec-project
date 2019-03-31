using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Connects the GUI to the core algorithm.
/// </summary>
/// 
public class VariableController : MonoBehaviour
{
    /// <summary>
    /// Reference to CoreAlgorithm
    /// </summary>
    [SerializeField]
    private CoreAlgorithm m_coreAlgorithm = null;

    /// <summary>
    /// Reference to the Main Panel.
    /// </summary>
    [SerializeField]
    private GameObject m_mainPanel = null;

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

    private void Start()
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
                if (m_sliderValueDisplays[i] == null || m_sliders[i] == null)
                {
                    Debug.Log("Error setting slider value displays; unequal number of sliders and value displays", gameObject);

                    return;
                }
            }

            UpdateHeatingPeriodSelection(0);

            UpdateThermostatSelection(0);

            UpdateMoistureProductionSelection(0);

            UpdateMoistureRemovalSelection(0);
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
        string _valueDisplayed = null;

        switch(_value)
        {
            case 0:
                _valueDisplayed = "Short";
                break;
            case 1:
                _valueDisplayed = "Medium";
                break;
            case 2:
                _valueDisplayed = "Long";
                break;
            default:
                break;
        }

        m_sliderValueDisplays[0].text = _valueDisplayed;

        m_coreAlgorithm.TemperatureModel.HeatingPeriodSelection = (int)_value;
    }

    /// <summary>
    /// Sets the thermostat setting in the temperature model. Used with a slider.
    /// </summary>
    /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
    public void UpdateThermostatSelection(float _value)
    {
        string _valueDisplayed = null;

        switch (_value)
        {
            case 0:
                _valueDisplayed = "Low";
                break;

            case 1:
                _valueDisplayed = "Medium";
                break;

            case 2:
                _valueDisplayed = "High";
                break;

            default:
                break;
        }

        m_sliderValueDisplays[1].text = _valueDisplayed;

        m_coreAlgorithm.TemperatureModel.ThermostatSettingSelection = (int)_value;
    }

    /// <summary>
    /// Sets the moisture production setting in the moisture model. Used with a slider.
    /// </summary>
    /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
    public void UpdateMoistureProductionSelection(float _value)
    {
        string _valueDisplayed = null;

        switch (_value)
        {
            case 0:
                _valueDisplayed = "Low";
                break;

            case 1:
                _valueDisplayed = "Medium";
                break;

            case 2:
                _valueDisplayed = "High";
                break;

            default:
                break;
        }

        m_sliderValueDisplays[2].text = _valueDisplayed;

        m_coreAlgorithm.MoistureModel.MoistureProductionSelection = (int)_value;
    }

    /// <summary>
    /// Sets the moisture removal setting in the moisture model. Used with a slider.
    /// </summary>
    /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
    public void UpdateMoistureRemovalSelection(float _value)
    {
        string _valueDisplayed = null;

        switch (_value)
        {
            case 0:
                _valueDisplayed = "Low";
                break;

            case 1:
                _valueDisplayed = "Medium";
                break;

            case 2:
                _valueDisplayed = "High";
                break;

            default:
                break;
        }

        m_sliderValueDisplays[3].text = _valueDisplayed;

        m_coreAlgorithm.MoistureModel.MoistureRemovalSelection = (int)_value;
    }

    /// <summary>
    /// Starts the simulation upon button press
    /// </summary>
    public void StartSimulation()
    {
        /// Starts the simulation if it is not ongoing
        m_coreAlgorithm.StartSimulation();
      
        /// Shows the Simulation Display GUI when the simulation starts
        m_simulationDisplayGUI.SetActive(true);
    }

    /// <summary>
    /// Stops the simulation upon button press.
    /// </summary>
    public void StopSimulation()
    {
        /// Stops the simulation if it is ongoing.
        m_coreAlgorithm.StopSimulation();

        /// Hides the Simulation Display GUI when the simulation stops.
        m_simulationDisplayGUI.SetActive(false);
    }
}

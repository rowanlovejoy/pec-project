using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableController : MonoBehaviour
{
    [SerializeField]
    private TemperatureModel m_tempModel;
    [SerializeField]
    private MoistureModel m_moistModel;

    /// <summary>
    /// Sets the heating period selection in the temperature model. Used with a slider.
    /// </summary>
    /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
    public void UpdateHeatingPeriodSelection(float _value)
    {
        m_tempModel.HeatingPeriodSelection = (int)_value;
    }

    /// <summary>
    /// Sets the thermostat setting in the temperature model. Used with a slider.
    /// </summary>
    /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
    public void UpdateThermostatSelection(float _value)
    {
        m_tempModel.ThermostatSettingSelection = (int)_value;
    }

    /// <summary>
    /// Sets the moisture production setting in the moisture model. Used with a slider.
    /// </summary>
    /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
    public void UpdateMoistureProductionSelection(float _value)
    {
        m_moistModel.MoistureProductionSelection = (int)_value;
    }

    /// <summary>
    /// Sets the moisture removal setting in the moisture model. Used with a slider.
    /// </summary>
    /// <param name="_value">Float value from slider - either 0, 1 or 2</param>
    public void UpdateMoistureRemovalSelection(float _value)
    {
        m_moistModel.MoistureRemovalSelection = (int)_value;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableController : MonoBehaviour
{
    public TemperatureModel tempModel;
    public MoistureModel moistModel;

    public void UpdateHeatingPeriodSelection(float value)
    {
        tempModel.HeatingPeriodSelection = (int)value;
    }

    public void UpdateThermostatSelection(float value)
    {
        tempModel.ThermostatSettingSelection = (int)value;
    }

    public void UpdateMoistureProductionSelection(float value)
    {
        moistModel.MoistureProductionSelection = (int)value;
    }

    public void UpdateMoistureRemovalSelection(float value)
    {
        moistModel.MoistureRemovalSelection = (int)value;
    }
}
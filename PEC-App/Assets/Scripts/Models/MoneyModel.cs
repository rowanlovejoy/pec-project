using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyModel : IAdjustable
{
    /// <summary>
    /// Reference to TemperatureModel.
    /// </summary>
    private TemperatureModel m_temperatureModel = null;

    /// <summary>
    /// The amount of money spent so far in the current simulation.
    /// </summary>
    private int m_moneySpent = 0;

    /// <summary>
    /// Constructor for MoneyModel. Initialises the TemperatureModel reference.
    /// </summary>
    /// <param name="_temperatureModel">Reference to a TemperatureModel instance.</param>
    public MoneyModel(TemperatureModel _temperatureModel)
    {
        m_temperatureModel = _temperatureModel;
    }

    /// <summary>
    /// Updates money spent based on whether heating is turned on during the current tick.
    /// </summary>
    /// <param name="_currentTick"></param>
    public void AdjustVariables(int _currentTick)
    {
        /// If heating is currently turned on, increase money spent.
        if (m_temperatureModel.HeatingIsOn)
        {
            m_moneySpent += 5;
        }

        /// Debug statements.
        Debug.Log("Money spent so far: " + m_moneySpent);
    }

    /// <summary>
    /// Resets simulation variables to default values.
    /// </summary>
    public void ResetVariables()
    {
        m_moneySpent = 0;
    }
}

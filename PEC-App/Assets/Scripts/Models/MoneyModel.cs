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
    public int MoneySpent { get; private set; } = 0;

    /// <summary>
    /// The amount of by which MoneySpent is increased by tick.
    /// </summary>
    [SerializeField]
    private int m_spendPerTick = 5;

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
            MoneySpent += 5;
        }

        /// Debug statements.
        Debug.Log("Money spent so far: " + MoneySpent);
    }

    /// <summary>
    /// Resets simulation variables to default values.
    /// </summary>
    public void ResetVariables()
    {
        MoneySpent = 0;
    }
}

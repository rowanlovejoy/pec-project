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

    public void AdjustVariables(int _currentTick)
    {
        /// If heating is currently turned on, increase money spent
        if (m_temperatureModel.HeatingIsOn)
        {
            m_moneySpent += 5;
        }
    }

    /// <summary>
    /// Resets simulation variables to default values
    /// </summary>
    public void ResetVariables()
    {
        m_moneySpent = 0;
    }
}

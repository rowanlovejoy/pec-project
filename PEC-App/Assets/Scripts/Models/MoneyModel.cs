﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyModel : IAdjustable
{
    /// <summary>
    /// The amount of money spent so far in the current simulation.
    /// </summary>
    private int m_moneySpent = 0;

    public void AdjustVariables(int _currentTick)
    {
        throw new System.NotImplementedException();
    }

    public void ResetVariables()
    {
        throw new System.NotImplementedException();
    }
}

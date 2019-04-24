using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouldModel : IAdjustable
{
    /// <summary>
    /// Reference to MoistureModel
    /// </summary>
    private MoistureModel m_moistureModel = null;

    /// <summary>
    /// Counter used to count how long wall saturation has been >= 70
    /// </summary>
    private int m_highSaturationCounter = 0;

    /// <summary>
    /// Counter used to count how long mould production has been active
    /// </summary>
    private int m_highMouldCounter = 0;

    /// <summary>
    /// Constructor for MouldModel. Initialises the MoistureModel reference.
    /// </summary>
    /// <param name="_model"></param>
    public MouldModel(MoistureModel _model)
    {
        m_moistureModel = _model;
    }

    /// <summary>
    /// Checks the wall saturation and calls mould events accordingly each tick.
    /// </summary>
    /// <param name="_tick">The current tick of the simulation.</param>
    public void AdjustVariables(int _tick)
    {
        /// if wall saturation is high enough for mould
        if (m_moistureModel.WallSaturation >= 70)
        {
            m_highSaturationCounter++;
        }
        /// else reset counter
        else
        {
            m_highSaturationCounter = 0;
        }

        /// if wall saturation has been high for 6 consecutive ticks (3 hours)
        if (m_highSaturationCounter >= 6)
        {
            EventManager.Instance.RaiseMouldProductionOnEvent();
            m_highMouldCounter++;
        }
        else
        {
            EventManager.Instance.RaiseMouldProductionOffEvent();
            m_highMouldCounter = 0;
        }

        /// if mould production has been active for 3 consecutive ticks (1.5 hours)
        if (m_highMouldCounter >= 3)
        {
            EventManager.Instance.RaiseHighMouldOnEvent();
        }
        else
        {
            EventManager.Instance.RaiseHighMouldOffEvent();
        }
    }

    /// <summary>
    /// Resets simulation variables to default values
    /// </summary>
    public void ResetVariables()
    {
        m_highSaturationCounter = 0;
        m_highMouldCounter = 0;
    }

}

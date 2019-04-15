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
    private int m_counter = 0;

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
            m_counter++;
        }
        /// else reset counter
        else
        {
            m_counter = 0;
        }

        /// if wall saturation has been high for 6 consecutive ticks (3 hours)
        if (m_counter >= 6)
        {
            EventManager.Instance.RaiseMouldProductionOnEvent();
        }
        else
        {
            EventManager.Instance.RaiseMouldProductionOffEvent();
        }
    }

    /// <summary>
    /// Resets simulation variables to default values
    /// </summary>
    public void ResetVariables()
    {
         m_counter = 0;
    }

}

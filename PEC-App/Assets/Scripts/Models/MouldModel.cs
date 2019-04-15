using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouldModel : IAdjustable
{
    private MoistureModel m_moistureModel = null;
    private int m_counter = 0;

    public MouldModel(MoistureModel _model)
    {
        m_moistureModel = _model;
    }

    public void AdjustVariables(int _tick)
    {
        if (m_moistureModel.WallSaturation >= 70)
        {
            m_counter++;
        }
        else
        {
            m_counter = 0;
        }

        if(m_counter >= 6)
        {
            EventManager.Instance.RaiseHighMouldOnEvent();
        }
        else
        {
            EventManager.Instance.RaiseHighMouldOffEvent();
        }
    }

    public void ResetVariables()
    {
         m_counter = 0;
    }

}

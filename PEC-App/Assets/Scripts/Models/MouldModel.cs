using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouldModel : IAdjustable
{
    private MoistureModel m_moistureModel = null;

    public MouldModel(MoistureModel _model)
    {
        m_moistureModel = _model;
    }

    public void AdjustVariables(int _tick)
    {

    }

    public void ResetVariables()
    {

    }

}

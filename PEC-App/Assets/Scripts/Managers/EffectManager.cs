﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_moistureEffects = null;

    [SerializeField]
    private GameObject[] m_condensationEffects = null;

    [SerializeField]
    private GameObject[] m_heatEffects = null;

    [SerializeField]
    private GameObject[] m_mouldEffects = null;

    [SerializeField]
    private CoreAlgorithm m_coreAlgorithm = null;

    void Start()
    {
        /// initialize setting to minimum
        HideAllEffects();
    }

    /// <summary>
    /// Enables moisture production effects based on the selection made by the user.
    /// </summary>
    public void EnableMoistureProductionEffects()
    {
        for (int i = 0; i < m_moistureEffects.Length; i++)
        {
            /// if group has been seleced
            if (i == m_coreAlgorithm.MoistureModel.MoistureProductionSelection)
            {
                /// enable (show) effects
                m_moistureEffects[i].SetActive(true);
            }
            else
            {
                /// disable (hide) effects
                m_moistureEffects[i].SetActive(false);
            }
        }
    }

    public void HideAllEffects()
    {

    }

}

using System.Collections;
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
    public void ShowMoistureProductionEffects()
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

    /// <summary>
    /// Disables all moisture production effects
    /// </summary>
    public void HideMoistureProductionEffects()
    {
        for (int i = 0; i < m_moistureEffects.Length; i++)
        {
            m_moistureEffects[i].SetActive(false);
        }
    }

    /// <summary>
    /// Enables all condensation effects
    /// </summary>
    public void ShowCondensationEffects()
    {
        for (int i = 0; i < m_condensationEffects.Length; i++)
        {
            m_condensationEffects[i].SetActive(true);
        }
    }

    /// <summary>
    /// Disables all condensation effects
    /// </summary>
    public void HideCondensationEffects()
    {
        for (int i = 0; i < m_condensationEffects.Length; i++)
        {
            m_condensationEffects[i].SetActive(false);
        }
    }


    /// <summary>
    /// Enables all Mould effects
    /// </summary>
    public void ShowMouldEffects()
    {
        for (int i = 0; i < m_mouldEffects.Length; i++)
        {
            m_mouldEffects[i].SetActive(true);
        }
    }
    /// <summary>
    /// Disables all condensation effects
    /// </summary>
    public void HideMouldEffects()
    {
        for (int i = 0; i < m_mouldEffects.Length; i++)
        {
            m_mouldEffects[i].SetActive(false);
        }
    }

    /// <summary>
    /// Disables all possible effects
    /// </summary>
    public void HideAllEffects()
    {
        for (int i = 0; i < m_moistureEffects.Length; i++)
        {
            m_moistureEffects[i].SetActive(false);
        }

        for (int i = 0; i < m_condensationEffects.Length; i++)
        {
            m_condensationEffects[i].SetActive(false);
        }

        for (int i = 0; i < m_heatEffects.Length; i++)
        {
            m_heatEffects[i].SetActive(false);
        }

        for (int i = 0; i < m_mouldEffects.Length; i++)
        {
            m_mouldEffects[i].SetActive(false);
        }
    }

}

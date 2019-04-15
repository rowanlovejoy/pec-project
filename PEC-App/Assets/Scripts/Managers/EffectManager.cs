using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    /// <summary>
    /// Array of Transforms containing group of particle systems as the children of each transform - Transforms represent low, medium, high
    /// </summary>
    [SerializeField]
    private Transform[] m_moistureEffects = null;

    /// <summary>
    /// Array of all condensation effects
    /// </summary>
    [SerializeField]
    private ParticleSystem[] m_condensationEffects = null;

    /// <summary>
    /// Array of all heat effects
    /// </summary>
    [SerializeField]
    private ParticleSystem[] m_heatEffects = null;

    /// <summary>
    /// Array of all mould effects
    /// </summary>
    [SerializeField]
    private ParticleSystem[] m_mouldEffects = null;

    /// <summary>
    /// Reference to core algorithm
    /// </summary>
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
            /// if group has been selected
            if (i == m_coreAlgorithm.MoistureModel.MoistureProductionSelection)
            {
                /// loop through group and start playing each particle system
                for (int j = 0; j < m_moistureEffects[i].childCount; j++)
                {
                    m_moistureEffects[i].GetChild(j).GetComponent<ParticleSystem>().Play();
                }
            }
            /// if group has not been selected
            else
            {
                /// loop through group and stop emmission of all particle systems
                for (int j = 0; j < m_moistureEffects[i].childCount; j++)
                {
                    m_moistureEffects[i].GetChild(j).GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
                }
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
            for (int j = 0; j < m_moistureEffects[i].childCount; j++)
            {
                m_moistureEffects[i].GetChild(j).GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
        }
    }

    /// <summary>
    /// Enables all condensation effects
    /// </summary>
    public void ShowCondensationEffects()
    {
        for (int i = 0; i < m_condensationEffects.Length; i++)
        {
            m_condensationEffects[i].Play();
        }
    }

    /// <summary>
    /// Disables all condensation effects
    /// </summary>
    public void HideCondensationEffects()
    {
        for (int i = 0; i < m_condensationEffects.Length; i++)
        {
            m_condensationEffects[i].Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }

    /// <summary>
    /// Enables all heat effects
    /// </summary>
    public void ShowHeatEffects()
    {
        for (int i = 0; i < m_heatEffects.Length; i++)
        {
            m_heatEffects[i].Play();
        }
    }

    /// <summary>
    /// Disables all heat effects
    /// </summary>
    public void HideHeatEffects()
    {
        for (int i = 0; i < m_heatEffects.Length; i++)
        {
            m_heatEffects[i].Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }

    /// <summary>
    /// Enables all Mould effects
    /// </summary>
    public void ShowMouldEffects()
    {
        Debug.Log("MOULD TRIGGERED!");
        for (int i = 0; i < m_mouldEffects.Length; i++)
        {
            m_mouldEffects[i].Play();
        }
    }

    /// <summary>
    /// Disables all condensation effects
    /// </summary>
    public void HideMouldEffects()
    {
        Debug.Log("MOULD HIDDEN!");
        for (int i = 0; i < m_mouldEffects.Length; i++)
        {
            m_mouldEffects[i].Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }

    /// <summary>
    /// Disables all possible effects
    /// </summary>
    public void HideAllEffects()
    {
        HideMoistureProductionEffects();

        HideHeatEffects();

        HideMouldEffects();

        HideCondensationEffects();
    }

}

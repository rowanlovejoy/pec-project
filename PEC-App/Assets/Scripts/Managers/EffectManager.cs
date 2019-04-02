using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_kettleSteam = null;

    [SerializeField]
    private GameObject m_potSteam = null;

    [SerializeField]
    private GameObject m_bathSteam = null;

    [SerializeField]
    private GameObject[] m_condensationEffects = null;

    [SerializeField]
    private GameObject[] m_heatEffects = null;

    [SerializeField]
    private GameObject[] m_mouldEffects = null;

    [SerializeField]
    private CoreAlgorithm m_coreAlgorithm = null;

   
}

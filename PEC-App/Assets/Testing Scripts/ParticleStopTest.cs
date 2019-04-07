using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStopTest : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem m_particleSystem = null;

    public void ToggleEmission()
    {
        if (m_particleSystem.isEmitting)
        {
            m_particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
        else if (!m_particleSystem.isEmitting)
        {
            m_particleSystem.Play();
        }
    }

    private void Update()
    {
        Debug.Log("Particle emitting: " + m_particleSystem.isEmitting);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimPlaybackSpeedAdjuster : MonoBehaviour
{
    /// <summary>
    /// Reference to CoreAlgorithm.
    /// </summary>
    [SerializeField]
    private CoreAlgorithm m_coreAlgorithm = null;

    /// <summary>
    /// Reference to this object's Animator component.
    /// </summary>
    [SerializeField]
    private Animator m_animator = null;

    private void Start()
    {
        /// Adjust the playback speed of the Animator based on the current simulation length value.
        m_animator.speed = (60 / m_coreAlgorithm.SimulationLength);
    }
}

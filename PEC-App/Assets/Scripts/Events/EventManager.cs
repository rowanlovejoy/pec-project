using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance = null;

    /// <summary>
    /// Reference to the startSimulation event
    /// </summary>
    [SerializeField]
    private GameEvent m_startSimulationEvent = null;

    /// <summary>
    /// Method called before Start function
    /// </summary>
    void Awake()
    {
        /// if instance does not already exist
        if (instance == null)
        {
            instance = this;
        }
        /// else if another instance already exists that is not this gameobject
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Raises the StartSimulation event.
    /// </summary>
    public void RaiseStartSimulationEvent()
    {
        if (m_startSimulationEvent != null)
        {
            m_startSimulationEvent.Raise();
        }
        else
        {
            Debug.LogError("The start simulation event has not been assigned.");
        }
    }
}

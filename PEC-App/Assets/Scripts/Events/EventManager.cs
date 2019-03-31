using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance = null;

    /// <summary>
    /// Reference to the StartSimulation event
    /// </summary>
    [SerializeField]
    private GameEvent m_startSimulationEvent = null;

    /// <summary>
    /// Reference to the StopSimulation event
    /// </summary>
    [SerializeField]
    private GameEvent m_stopSimulationEvent = null;

    /// <summary>
    /// Reference to the EndSimulation event
    /// </summary>
    [SerializeField]
    private GameEvent m_endSimulationEvent = null;

    /// <summary>
    /// Reference to the HeatingOn event
    /// </summary>
    [SerializeField]
    private GameEvent m_heatingOnEvent = null;

    /// <summary>
    /// Reference to the HeatingOff event
    /// </summary>
    [SerializeField]
    private GameEvent m_heatingOffEvent = null;

    /// <summary>
    /// Reference to the MoistureProductionOn event
    /// </summary>
    [SerializeField]
    private GameEvent m_moistureProductionOnEvent = null;


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
        /// error handling
        if (m_startSimulationEvent != null)
        {
            m_startSimulationEvent.Raise();
        }
        else
        {
            Debug.LogError("The start simulation event has not been assigned.");
        }
    }

    /// <summary>
    /// Raises the StopSimulation event.
    /// </summary>
    public void RaiseStopSimulationEvent()
    {
        /// error handling
        if (m_stopSimulationEvent != null)
        {
            m_stopSimulationEvent.Raise();
        }
        else
        {
            Debug.LogError("The stop simulation event has not been assigned.");
        }
    }

    /// <summary>
    /// Raises the EndSimulation event.
    /// </summary>
    public void RaiseEndSimulationEvent()
    {
        /// error handling
        if (m_endSimulationEvent != null)
        {
            m_endSimulationEvent.Raise();
        }
        else
        {
            Debug.LogError("The end simulation event has not been assigned.");
        }
    }

    /// <summary>
    /// Raises the HeatingOn event.
    /// </summary>
    public void RaiseHeatingOnEvent()
    {
        /// error handling
        if (m_heatingOnEvent != null)
        {
            m_heatingOnEvent.Raise();
        }
        else
        {
            Debug.LogError("The heating on event has not been assigned.");
        }
    }

    /// <summary>
    /// Raises the HeatingOff event.
    /// </summary>
    public void RaiseHeatingOffEvent()
    {
        /// error handling
        if (m_heatingOffEvent != null)
        {
            m_heatingOffEvent.Raise();
        }
        else
        {
            Debug.LogError("The heating off event has not been assigned.");
        }
    }

    /// <summary>
    /// Raises the MoistureProductionOn event.
    /// </summary>
    public void RaiseMoistureProductionOnEvent()
    {
        /// error handling
        if (m_moistureProductionOnEvent != null)
        {
            m_moistureProductionOnEvent.Raise();
        }
        else
        {
            Debug.LogError("The moisture production on event has not been assigned.");
        }
    }

    
}

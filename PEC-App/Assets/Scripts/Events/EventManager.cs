﻿using System.Collections;
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
    /// Reference to the PauseSimulation event
    /// </summary>
    [SerializeField]
    private GameEvent m_pauseSimulationEvent = null;

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
    /// Reference to the MoistureProductionOff event
    /// </summary>
    [SerializeField]
    private GameEvent m_moistureProductionOffEvent = null;

    /// <summary>
    /// Reference to the MouldProductionOn event
    /// </summary>
    [SerializeField]
    private GameEvent m_mouldProductionOnEvent = null;

    /// <summary>
    /// Reference to the MouldProductionOff event
    /// </summary>
    [SerializeField]
    private GameEvent m_mouldProductionOffEvent = null;

    /// <summary>
    /// Reference to the EndScreenClose event
    /// </summary>
    [SerializeField]
    private GameEvent m_endScreenCloseEvent = null;

    /// <summary>
    /// Reference to the StatScreenOpen event
    /// </summary>
    [SerializeField]
    private GameEvent m_statScreenOpenEvent = null;

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
    /// Raises the PauseSimulation event.
    /// </summary>
    public void RaisePauseSimulationEvent()
    {
        /// error handling
        if (m_pauseSimulationEvent != null)
        {
            m_pauseSimulationEvent.Raise();
        }
        else
        {
            Debug.LogError("The pause simulation event has not been assigned.");
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

    /// <summary>
    /// Raises the MoistureProductionOff event.
    /// </summary>
    public void RaiseMoistureProductionOffEvent()
    {
        /// error handling
        if (m_moistureProductionOffEvent != null)
        {
            m_moistureProductionOffEvent.Raise();
        }
        else
        {
            Debug.LogError("The moisture production off event has not been assigned.");
        }
    }

    /// <summary>
    /// Raises the MouldProductionOn event.
    /// </summary>
    public void RaiseMouldProductionOnEvent()
    {
        /// error handling
        if (m_mouldProductionOnEvent != null)
        {
            m_mouldProductionOnEvent.Raise();
        }
        else
        {
            Debug.LogError("The mould production on event has not been assigned.");
        }
    }

    /// <summary>
    /// Raises the MouldProductionOff event.
    /// </summary>
    public void RaiseMouldProductionOffEvent()
    {
        /// error handling
        if (m_mouldProductionOffEvent != null)
        {
            m_mouldProductionOffEvent.Raise();
        }
        else
        {
            Debug.LogError("The mould production off event has not been assigned.");
        }
    }

    /// <summary>
    /// Raises the EndScreenClose event.
    /// </summary>
    public void RaiseEndScreenCloseEvent()
    {
        /// error handling
        if (m_endScreenCloseEvent != null)
        {
            m_endScreenCloseEvent.Raise();
        }
        else
        {
            Debug.LogError("The end screen close event has not been assigned.");
        }
    }

    /// <summary>
    /// Raises the StatScreenOpen event.
    /// </summary>
    public void RaiseStatScreenOpenEvent()
    {
        /// error handling
        if (m_statScreenOpenEvent != null)
        {
            m_statScreenOpenEvent.Raise();
        }
        else
        {
            Debug.LogError("The stat screen open event has not been assigned.");
        }
    }
}

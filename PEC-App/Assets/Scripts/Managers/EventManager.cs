using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    /// <summary>
    /// Instance of the EventManager singleton.
    /// </summary>
    public static EventManager Instance { get; private set; } = null;

    #region EVENT VARIABLES
    [Header("Simulation Events")]
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
    /// Reference to the ResetSimulation event
    /// </summary>
    [SerializeField]
    private GameEvent m_resetSimulationEvent = null;

    [Header("Heating Events")]
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

    [Header("Moisture Production Events")]
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

    [Header("Condensation Events")]
    /// <summary>
    /// Reference to the CondensationOn event
    /// </summary>
    [SerializeField]
    private GameEvent m_condensationOnEvent = null;

    /// <summary>
    /// Reference to the CondensationOff event
    /// </summary>
    [SerializeField]
    private GameEvent m_condensationOffEvent = null;

    [Header("Mould Production Events")]
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

    [Header("GUI Events")]
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
    /// Reference to the StatScreenClose event
    /// </summary>
    [SerializeField]
    private GameEvent m_statScreenCloseEvent = null;

    [Header("Low Temperature Events")]
    /// <summary>
    /// Reference to the LowTemperatureOn event
    /// </summary>
    [SerializeField]
    private GameEvent m_lowTemperatureOnEvent = null;

    /// <summary>
    /// Reference to the LowTemperatureOff event
    /// </summary>
    [SerializeField]
    private GameEvent m_lowTemperatureOffEvent = null;

    [Header("High Mould Events")]
    /// <summary>
    /// Reference to the HighMouldOn event
    /// </summary>
    [SerializeField]
    private GameEvent m_highMouldOnEvent = null;

    /// <summary>
    /// Reference to the HighMouldOff event
    /// </summary>
    [SerializeField]
    private GameEvent m_highMouldOffEvent = null;

    [Header("Day Events")]
    /// <summary>
    /// Reference to the DayStart event
    /// </summary>
    [SerializeField]
    private GameEvent m_dayStartEvent = null;

    /// <summary>
    /// Reference to the DayEnd event
    /// </summary>
    [SerializeField]
    private GameEvent m_dayEndEvent = null;

    /// <summary>
    /// Reference to the OnSimulationTick event.
    /// </summary>
    [SerializeField]
    private GameEvent m_onSimulationTick = null;
    #endregion

    /// <summary>
    /// Method called before Start function
    /// </summary>
    void Awake()
    {
        /// if instance does not already exist
        if (Instance == null)
        {
            Instance = this;
        }
        /// else if another instance already exists that is not this gameobject
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    #region SIMULATION EVENTS
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
    /// Raises the ResetSimulation event.
    /// </summary>
    public void RaiseResetSimulationEvent()
    {
        /// error handling
        if (m_resetSimulationEvent != null)
        {
            m_resetSimulationEvent.Raise();
        }
        else
        {
            Debug.LogError("The reset simulation event has not been assigned.");
        }
    }
    /// <summary>
    /// Raises the OnSimulationTick event, every tick.
    /// </summary>
    public void OnSimulationTick()
    {
        if (m_onSimulationTick != null)
        {
            m_onSimulationTick.Raise();
        }
        else
        {
            Debug.LogError("The on simulation tick event has not been assigned.");
        }
    }
    #endregion

    #region HEATING EVENTS
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
    #endregion

    #region MOISTURE PRODUCTION EVENTS
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
    #endregion

    #region CONDENSATION EVENTS
    /// <summary>
    /// Raises the CondensationOn event.
    /// </summary>
    public void RaiseCondensationOnEvent()
    {
        /// error handling
        if (m_condensationOnEvent != null)
        {
            m_condensationOnEvent.Raise();
        }
        else
        {
            Debug.LogError("The condensation on event has not been assigned.");
        }
    }

    /// <summary>
    /// Raises the CondensationOff event.
    /// </summary>
    public void RaiseCondensationOffEvent()
    {
        /// error handling
        if (m_condensationOffEvent != null)
        {
            m_condensationOffEvent.Raise();
        }
        else
        {
            Debug.LogError("The condensation off event has not been assigned.");
        }
    }
    #endregion

    #region MOULD PRODUCTION EVENTS
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
    #endregion

    #region GUI EVENTS
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

    /// <summary>
    /// Raises the StatScreenClose event.
    /// </summary>
    public void RaiseStatScreenCloseEvent()
    {
        /// error handling
        if (m_statScreenCloseEvent != null)
        {
            m_statScreenCloseEvent.Raise();
        }
        else
        {
            Debug.LogError("The stat screen close event has not been assigned.");
        }
    }
    #endregion

    #region LOW TEMPERATURE EVENTS
    /// <summary>
    /// Raises the LowTemperatureOn event.
    /// </summary>
    public void RaiseLowTemperatureOnEvent()
    {
        /// error handling
        if (m_lowTemperatureOnEvent != null)
        {
            m_lowTemperatureOnEvent.Raise();
        }
        else
        {
            Debug.LogError("The low temperature on event has not been assigned.");
        }
    }

    /// <summary>
    /// Raises the LowTemperatureOff event.
    /// </summary>
    public void RaiseLowTemperatureOffEvent()
    {
        /// error handling
        if (m_lowTemperatureOffEvent != null)
        {
            m_lowTemperatureOffEvent.Raise();
        }
        else
        {
            Debug.LogError("The low temperature off event has not been assigned.");
        }
    }
    #endregion

    #region HIGH MOULD EVENTS
    /// <summary>
    /// Raises the HighMouldOn event.
    /// </summary>
    public void RaiseHighMouldOnEvent()
    {
        /// error handling
        if (m_highMouldOnEvent != null)
        {
            m_highMouldOnEvent.Raise();
        }
        else
        {
            Debug.LogError("The high mould on event has not been assigned.");
        }
    }

    /// <summary>
    /// Raises the HighMouldOff event.
    /// </summary>
    public void RaiseHighMouldOffEvent()
    {
        /// error handling
        if (m_highMouldOffEvent != null)
        {
            m_highMouldOffEvent.Raise();
        }
        else
        {
            Debug.LogError("The high mould off event has not been assigned.");
        }
    }
    #endregion

    #region DAY EVENTS
    /// <summary>
    /// Raises the DayStart event.
    /// </summary>
    public void RaiseDayStartEvent()
    {
        /// error handling
        if (m_dayStartEvent != null)
        {
            m_dayStartEvent.Raise();
        }
        else
        {
            Debug.LogError("The day start event has not been assigned.");
        }
    }

    /// <summary>
    /// Raises the DayEnd event.
    /// </summary>
    public void RaiseDayEndEvent()
    {
        /// error handling
        if (m_dayEndEvent != null)
        {
            m_dayEndEvent.Raise();
        }
        else
        {
            Debug.LogError("The day end event has not been assigned.");
        }
    }
    #endregion
}

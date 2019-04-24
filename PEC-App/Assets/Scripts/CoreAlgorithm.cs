using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Contains the core algorithm which powers the simulation.
/// </summary>
public class CoreAlgorithm : MonoBehaviour
{
    /// <summary>
    /// Reference to TemperatureModel instance.
    /// </summary>
    public TemperatureModel TemperatureModel { get; private set; } = null;

    /// <summary>
    /// Reference to MoistureModel instance.
    /// </summary>
    public MoistureModel MoistureModel { get; private set; } = null;

    /// <summary>
    /// Reference to MoneyModel instance.
    /// </summary>
    public MoneyModel MoneyModel { get; private set; } = null;

    /// <summary>
    /// Reference to MouldModel instance.
    /// </summary>
    public MouldModel MouldModel { get; private set; } = null;

    /// <summary>
    /// Indicates if the simulation is paused or not while in progress.
    /// </summary>
    public bool IsPaused { get; private set; } = false;

    /// <summary>
    /// Array of all model classes.
    /// </summary>
    private IAdjustable[] m_models;

    /// <summary>
    /// The actual length of time in seconds the simulation runs.
    /// </summary>
    private float m_simulationLength = 60f;

    /// <summary>
    /// The length of each simulation tick.
    /// Equal to the length of the simulation divided 48, so each tick is half an hour of simulation represented in seconds.
    /// </summary>
    private float m_tickLength;

    /// <summary>
    /// The current simulation tick number.
    /// </summary>
    private int m_currentTick = 0;

    /// <summary>
    /// Indicates if the simulation is on going. True if so; false otherwise.
    /// </summary>
    private bool m_simulationInProgress = false;

    /// <summary>
    /// Cache of EventManager singleton instance
    /// </summary>
    private EventManager m_eventManager;

    private void Awake()
    {
        TemperatureModel = new TemperatureModel();

        MoistureModel = new MoistureModel(TemperatureModel);

        MoneyModel = new MoneyModel(TemperatureModel);

        MouldModel = new MouldModel(MoistureModel);

        m_models = new IAdjustable[4] { TemperatureModel, MoistureModel, MoneyModel, MouldModel };

        m_tickLength = m_simulationLength / 48;
    }

    private void Start()
    {
        /// caching 
        m_eventManager = EventManager.Instance;
    }

    /// <summary>
    /// Starts the simulation.
    /// </summary>
    public void StartSimulation()
    {
        /// Checks that the simulation has not already started.
        if (!m_simulationInProgress)
        {
            Debug.Log("Simulation starting");

            /// Always reset MoneyModel variables
            MoneyModel.ResetVariables();

            m_simulationInProgress = true;

            IsPaused = false;

            m_eventManager.RaiseStartSimulationEvent();

            StartCoroutine(Tick(m_tickLength)); 
        }
        else
        {
            Debug.LogWarning("Simulation already in progress.");
        }
    }

    /// <summary>
    /// Run once per tick of the simulation. Calls upon simulation models to update the simulation state.
    /// </summary>
    /// <param name="_tickLength">Length of a tick in seconds.</param>
    IEnumerator Tick(float _tickLength)
    {
        while (m_currentTick < 48)
        {
            while (IsPaused)
            {
                yield return null;
            }

            Debug.Log("TICK: " + m_currentTick);

            if (m_currentTick == 10)
            {
                m_eventManager.RaiseDayStartEvent();
            }
            else if (m_currentTick == 38)
            {
                m_eventManager.RaiseDayEndEvent();
            }

            foreach (IAdjustable model in m_models)
            {
                model.AdjustVariables(m_currentTick);
            }

            m_currentTick++;

            m_eventManager.RaiseOnSimulationTick();
            /// Wait time period for animations

            yield return new WaitForSeconds(_tickLength); 
        }

        EndSimulation();
    }

    /// <summary>
    /// Pauses the simulation and triggers the PauseSimulation event
    /// </summary>
    public void PauseAndResumeSimulation()
    {
        /// if simulation has started and is playing
        if (m_simulationInProgress)
        {
            if (!IsPaused)
            {
                IsPaused = true;

                Time.timeScale = 0f;

                EventManager.Instance.RaisePauseSimulationEvent();

                Debug.Log("The simulation has been paused.");
            }
            else
            {
                IsPaused = false;

                Time.timeScale = 1f;

                Debug.Log("The simulation has been resumed.");
            }
        }
        else
        {
            Debug.LogWarning("Cannot pause or resume simulation as it is not in progress.");
        }
    }

    /// <summary>
    /// Resumes simulation if it is paused.
    /// </summary>
    private void ResumeSimulation()
    {
        if (IsPaused)
        {
            IsPaused = false;

            Time.timeScale = 1f;
        }
    }

    /// <summary>
    /// Natural end to the simulation.
    /// </summary>
    private void EndSimulation()
    {
        m_simulationInProgress = false;

        m_eventManager.RaiseEndSimulationEvent();

        ResetSimulationTick();

        Debug.Log("The simulation has ended.");
    }

    /// <summary>
    /// Prematurely stops the simulation by stopping all coroutines.
    /// </summary>
    public void StopSimulation()
    {
        /// this is for if the simulation is stopped while it is paused
        ResumeSimulation();

        m_simulationInProgress = false;

        StopAllCoroutines();
        ResetSimulationTick();
        ResetValues();

        m_eventManager.RaiseStopSimulationEvent();

        Debug.Log("The simulation has been stopped prematurely.");
    }

    /// <summary>
    /// Resets the tick and all simulation values in the models
    /// </summary>
    private void ResetSimulationTick()
    {
        m_currentTick = 0;
    }

    /// <summary>
    /// Resets all simulation values in the models.
    /// </summary>
    public void ResetValues()
    {
        foreach (IAdjustable model in m_models)
        {
            model.ResetVariables();
        }

        EventManager.Instance.RaiseResetSimulationEvent();
    }
}
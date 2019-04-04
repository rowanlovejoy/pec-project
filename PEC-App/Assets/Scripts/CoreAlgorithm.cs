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

        m_models = new IAdjustable[2] { TemperatureModel, MoistureModel };

        m_tickLength = m_simulationLength / 48;
    }

    private void Start()
    {
        /// caching 
        m_eventManager = EventManager.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartSimulation();
        }
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

            m_simulationInProgress = true;

            m_eventManager.RaiseStartSimulationEvent();

            StartCoroutine(Tick(m_tickLength)); 
        }
        else
        {
            Debug.LogError("Simulation already in progress.");
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

            /// Wait time period for animations
            yield return new WaitForSeconds(_tickLength); 

            m_currentTick++;
        }

        EndSimulation();
    }

    /// <summary>
    /// Natural end to the simulation.
    /// </summary>
    private void EndSimulation()
    {
        m_simulationInProgress = false;

        m_eventManager.RaiseEndSimulationEvent();

        ResetValues();

        Debug.Log("The simulation has ended.");
    }

    /// <summary>
    /// Prematurely stops the simulation by stopping all coroutines.
    /// </summary>
    public void StopSimulation()
    {
        m_simulationInProgress = false;

        m_eventManager.RaiseStopSimulationEvent();

        StopAllCoroutines();
        ResetValues();

        Debug.Log("The simulation has been stopped prematurely.");
    }

    /// <summary>
    /// Resets all simulation values in the models.
    /// </summary>
    private void ResetValues()
    {
        m_currentTick = 0;

        foreach (IAdjustable model in m_models)
        {
            model.ResetVariables();
        }
    }
}
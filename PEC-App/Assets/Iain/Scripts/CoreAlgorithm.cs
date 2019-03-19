using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreAlgorithm : MonoBehaviour
{
    public TemperatureModel temperatureModel;
    public MoistureModel moistureModel;

    // Simulation Variables
    private float m_simulationLength = 60f; // the actual length of time in seconds the simulation runs
    private float m_tickLength; // simulationLength / 48 so each tick is half an hour of simulation represented in seconds
    private int m_currentTick = 0;
    private bool m_simulationInProgress = false;

    private void Start()
    {
        temperatureModel = new TemperatureModel();
        moistureModel = new MoistureModel(temperatureModel);
        m_tickLength = m_simulationLength / 48;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartSimulation();
        }
    }

    public void StartSimulation()
    {
        // if simulation is not already in progress
        if (!m_simulationInProgress)
        {
            Debug.Log("Simulation starting");
            m_simulationInProgress = true;
            StartCoroutine(Tick(m_tickLength)); // start simulation
        }
        else
        {
            Debug.LogError("Simulation already in progress.");
        }
    }

    IEnumerator Tick(float tickLength)
    {
        Debug.Log("TICK: " + m_currentTick);

        temperatureModel.AdjustHeating(m_currentTick);

        moistureModel.AdjustMoisture(m_currentTick);

        yield return new WaitForSeconds(tickLength);

        if (m_currentTick < 47)
        {
            m_currentTick++;
            StartCoroutine(Tick(tickLength));
        }
        else
        {
            EndSimulation();
        }
    }

    private void EndSimulation()
    {
        m_simulationInProgress = false;
        Debug.Log("The simulation has ended.");
    }

    private void StopSimulation()
    {
        m_simulationInProgress = false;
        Debug.Log("The simulation has been stopped prematurely.");
    }
}

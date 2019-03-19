using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreAlgorithm : MonoBehaviour
{
    public TemperatureModel temperatureModel;
    public MoistureModel moistureModel;

    // Simulation Variables
    private float simulationLength = 60f; // the actual length of time in seconds the simulation runs
    private float tickLength; // simulationLength / 48 so each tick is half an hour of simulation represented in seconds
    private int currentTick = 0;
    private bool m_simulationInProgress = false;

    private void Start()
    {
        tickLength = simulationLength / 48;
    }

    private void StartSimulation()
    {
        Debug.Log("Simulation starting");
        StartCoroutine(Tick(tickLength));
    }

    IEnumerator Tick(float tickLength)
    {
        Debug.Log("\n\nTICK: " + currentTick);

        temperatureModel.AdjustHeating(currentTick);

        moistureModel.AdjustMoisture();

        yield return new WaitForSeconds(tickLength);

        if (currentTick < 47)
        {
            currentTick++;
            StartCoroutine(Tick(tickLength));
        }
        else
        {
            EndSimulation();
        }
    }

    private void EndSimulation()
    {
        Debug.Log("The simulation has ended.");
    }

    private void StopSimulation()
    {
        Debug.Log("The simulation has been stopped prematurely.");
    }
}

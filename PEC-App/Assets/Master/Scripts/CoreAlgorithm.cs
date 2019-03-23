using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    public class CoreAlgorithm : MonoBehaviour
    {
        /// <summary>
        /// References to simulation model classes
        /// </summary>
        public TemperatureModel TemperatureModel { get; private set; } = null;
        public MoistureModel MoistureModel { get; private set; } = null;

        // Simulation Variables
        private float m_simulationLength = 60f; // the actual length of time in seconds the simulation runs
        private float m_tickLength; // simulationLength / 48 so each tick is half an hour of simulation represented in seconds
        private int m_currentTick = 0;
        private bool m_simulationInProgress = false;

        private void Awake()
        {
            TemperatureModel = new TemperatureModel();

            MoistureModel = new MoistureModel(TemperatureModel);

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

        /// <summary>
        /// Starts the simulation
        /// </summary>
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

        /// <summary>
        /// Single step of simulation where all calculations are made.
        /// </summary>
        /// <param name="_tickLength">Length of tick in seconds</param>
        IEnumerator Tick(float _tickLength)
        {
            while (m_currentTick < 47)
            {
                Debug.Log("TICK: " + m_currentTick);

                TemperatureModel.AdjustHeating(m_currentTick);

                MoistureModel.AdjustMoisture(m_currentTick);

                yield return new WaitForSeconds(_tickLength); // wait time period for animations

                m_currentTick++;
            }

            EndSimulation();
        }

        /// <summary>
        /// Natural end to simulation.
        /// </summary>
        private void EndSimulation()
        {
            m_simulationInProgress = false;

            Debug.Log("The simulation has ended.");
        }

        /// <summary>
        /// Prematurely stops the simulation by stopping all coroutines.
        /// </summary>
        public void StopSimulation()
        {
            m_simulationInProgress = false;

            StopAllCoroutines();

            Debug.Log("The simulation has been stopped prematurely.");
        }
    }
}
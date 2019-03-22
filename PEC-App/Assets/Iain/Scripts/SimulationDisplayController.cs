using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    /// <summary>
    /// Controls Simulation Display GUI
    /// </summary>
    public class SimulationDisplayController : MonoBehaviour
    {
        /// <summary>
        /// Reference to CoreAlgorithm
        /// </summary>
        [SerializeField]
        private CoreAlgorithm m_coreAlgorithm = null;

        /// <summary>
        /// Stops the simulation upon button press
        /// </summary>
        public void StopSimulation()
        {
            m_coreAlgorithm.StopSimulation();
        }
    }
}
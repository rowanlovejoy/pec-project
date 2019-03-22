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
        /// Reference to the Main Panel
        /// </summary>
        [SerializeField]
        private GameObject m_mainPanel = null;

        /// <summary>
        /// Stops the simulation upon button press
        /// </summary>
        public void StopSimulation()
        {
            /// Stops the simulation if it is ongoing
            m_coreAlgorithm.StopSimulation();
            /// Hides the Simulation Display GUI when the simulation stops
            gameObject.SetActive(false);
            /// Shows the Main Panel when the simulation stops
            m_mainPanel.SetActive(true);
        }
    }
}
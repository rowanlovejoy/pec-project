using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatsScreenCalculator : MonoBehaviour
{
    /// <summary>
    /// A reference to an  air saturation TMPro text component.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI m_airSat;
 
    /// <summary>
    ///  A reference to a wall saturation TMPro text component.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI m_wallSat;
 
    /// <summary>
    /// A reference to a cost TMPro text component.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI m_cost;

    /// <summary>
    /// A reference to CoreAlgorithm.
    /// </summary>

    [SerializeField]
    private CoreAlgorithm m_coreAlgorithm;

    // Update is called once per frame
    public void StatScreenUpdate()
    {
        m_airSat.text = "Dampness of Air: " + m_coreAlgorithm.MoistureModel.AirSaturation + " / 100";

        m_wallSat.text = "Dampness of Walls: " + m_coreAlgorithm.MoistureModel.WallSaturation + " / 100";

        m_cost.text = "Cost: " + m_coreAlgorithm.MoneyModel.MoneySpent + " / 40";
    }
}


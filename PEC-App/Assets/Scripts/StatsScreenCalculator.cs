using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StatsScreenCalculator : MonoBehaviour
{
    /// <summary>
    /// A reference to a maximum cost value that can be manually set in the editor.
    /// </summary>
    [SerializeField]
    private int m_maxCost = 60;

    /// <summary>
    /// A reference to a maximum air saturation value that can be manually set in the editor.
    /// </summary>
    [SerializeField]
    private int m_maxAirSat = 100;

    /// <summary>
    /// A reference to a maximum wall saturation value that can be manually set in the editor.
    /// </summary>
    [SerializeField]
    private int m_maxWallSat = 100;

    /// <summary>
    /// A reference to an  air saturation TMPro text component.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI m_airSatText;
 
    /// <summary>
    ///  A reference to a wall saturation TMPro text component.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI m_wallSatText;
 
    /// <summary>
    /// A reference to a cost TMPro text component.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI m_costText;

    /// <summary>
    /// A reference to a temperature TMPro text component.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI m_tempText;

    /// <summary>
    /// A reference to CoreAlgorithm.
    /// </summary>
    [SerializeField]
    private CoreAlgorithm m_coreAlgorithm;

    /// <summary>
    /// Updates the information within the Stats Screen.
    /// </summary>
    public void StatScreenUpdate()
    {
        m_airSatText.text = "Dampness of Air: " + m_coreAlgorithm.MoistureModel.AirSaturation + " / " + m_maxAirSat + "L";

        m_wallSatText.text = "Dampness of Walls: " + m_coreAlgorithm.MoistureModel.WallSaturation + " / " + m_maxWallSat + "L";

        m_costText.text = "Cost: " + m_coreAlgorithm.MoneyModel.MoneySpent + " / £" + m_maxCost;

        m_tempText.text = "Temperature: " + Math.Round(m_coreAlgorithm.TemperatureModel.AirTemperature) + "°C";
    }
}


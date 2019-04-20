using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatsScreenCalculator : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_airSat;
    [SerializeField]
    private TextMeshProUGUI m_wallSat;
    [SerializeField]
    private TextMeshProUGUI m_cost;

    [SerializeField]
    private CoreAlgorithm m_coreAlgorithm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_airSat.text = "Dampness of Air: " + m_coreAlgorithm.MoistureModel.AirSaturation + " / 100";

        m_wallSat.text = "Dampness of Walls: " + m_coreAlgorithm.MoistureModel.WallSaturation + " / 100";
    }
}


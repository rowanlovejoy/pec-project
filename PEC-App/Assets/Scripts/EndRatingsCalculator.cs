using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRatingsCalculator : MonoBehaviour
{
    /// <summary>
    /// The ideal wall saturation value. Used to determine final wall saturation rating.
    /// </summary>
    [SerializeField]
    private float m_idealWallSaturation;

    /// <summary>
    /// The ideal air saturation value. Used to determine final air saturation rating.
    /// </summary>
    [SerializeField]
    private float m_idealAirSaturation;

    /// <summary>
    /// The ideal money spent value. Used to determine final air saturation rating.
    /// </summary>
    [SerializeField]
    private float m_idealMondaySpent;

    /// <summary>
    /// The final wall saturation rating value.
    /// </summary>
    private float m_wallSaturationRating = 0;

    /// <summary>
    /// The final air saturation rating value.
    /// </summary>
    private float m_airSaturationRating = 0;

    /// <summary>
    /// The final money spent rating value.
    /// </summary>
    private float m_moneySpentRating = 0;
}

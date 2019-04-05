using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRatingsCalculator : MonoBehaviour
{
    /// <summary>
    /// Reference to core algorithm. Used to access models to obtain final values used in ratings calculation.
    /// </summary>
    [SerializeField]
    private CoreAlgorithm m_coreAlgorithm = null;

    /// <summary>
    /// The ideal wall saturation value. Used to determine final wall saturation rating.
    /// </summary>
    [SerializeField]
    private int m_idealWallSaturation;

    /// <summary>
    /// The ideal air saturation value. Used to determine final air saturation rating.
    /// </summary>
    [SerializeField]
    private int m_idealAirSaturation;

    /// <summary>
    /// The ideal money spent value. Used to determine final air saturation rating.
    /// </summary>
    [SerializeField]
    private int m_idealMondaySpent;

    /// <summary>
    /// The final wall saturation rating value.
    /// </summary>
    private int m_wallSaturationRating = 0;

    /// <summary>
    /// The final air saturation rating value.
    /// </summary>
    private int m_airSaturationRating = 0;

    /// <summary>
    /// The final money spent rating value.
    /// </summary>
    private int m_moneySpentRating = 0;

    public void CalculateEndRatings()
    {
        m_wallSaturationRating = Mathf.Abs(m_idealWallSaturation - m_coreAlgorithm.MoistureModel.WallSaturation);

        m_airSaturationRating = Mathf.Abs(m_idealAirSaturation - m_coreAlgorithm.MoistureModel.AirSaturation);

        m_moneySpentRating = Mathf.Abs(m_idealMondaySpent - m_coreAlgorithm.MoneyModel.MoneySpent);

        Debug.Log("Ratings - Wall Sat: " + m_wallSaturationRating + " - Air Sat: " + m_airSaturationRating + " - Money Spent: " + m_moneySpentRating);
    }
}

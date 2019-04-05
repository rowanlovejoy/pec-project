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
        m_wallSaturationRating = CalculateRating(m_idealWallSaturation, m_coreAlgorithm.MoistureModel.WallSaturation);

        m_airSaturationRating = CalculateRating(m_airSaturationRating, m_coreAlgorithm.MoistureModel.AirSaturation);

        m_moneySpentRating = CalculateRating(m_idealMondaySpent, m_coreAlgorithm.MoneyModel.MoneySpent);

        Debug.Log("Ratings - Wall Sat: " + m_wallSaturationRating + " - Air Sat: " + m_airSaturationRating + " - Money Spent: " + m_moneySpentRating);
    }

    private int CalculateRating(int _idealValue, int _actualValue)
    {
        int _highestNumber = Mathf.Max(_idealValue, _actualValue);

        int _lowestNumber = Mathf.Min(_idealValue, _actualValue);

        int _difference = _highestNumber - _lowestNumber;

        int _rating = 0;

        if (_difference <= 5)
        {
            _rating = 5;
        }
        else if (_difference <= 10)
        {
            _rating = 4;
        }
        else if (_difference <= 15)
        {
            _rating = 3;
        }
        else if (_difference <= 20)
        {
            _rating = 2;
        }
        else
        {
            _rating = 1;
        }

        return _rating;
    }
}

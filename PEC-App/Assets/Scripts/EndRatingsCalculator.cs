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
    /// Reference to EndRatingsDisplayManager.
    /// </summary>
    [SerializeField]
    private EndRatingsDisplayManager m_endRatingsDisplayManager = null;

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
    public int WallSaturationRating { get; private set; } = 0;

    /// <summary>
    /// The final air saturation rating value.
    /// </summary>
    public int AirSaturationRating { get; private set; } = 0;

    /// <summary>
    /// The final money spent rating value.
    /// </summary>
    public int MoneySpentRating { get; private set; } = 0;

    /// <summary>
    /// Calculate the rating for a value based on the difference between it and its corresponding ideal value.
    /// </summary>
    /// <param name="_idealValue">The ideal for this rated value.</param>
    /// <param name="_actualValue">The final value to be rated.</param>
    /// <returns>The calculated rating for the given actual value.</returns>
    private int CalculateRating(int _idealValue, int _actualValue)
    {
        /// Determine which is the highest value between the ideal and actual.
        int _highestNumber = Mathf.Max(_idealValue, _actualValue);

        /// Determine which is the lowest value between the ideal and actual.
        int _lowestNumber = Mathf.Min(_idealValue, _actualValue);

        /// Calculate the difference between the values determined to be the highest and lowest.
        int _difference = _highestNumber - _lowestNumber;

        /// Variable to store the calculated rating.
        int _rating = 0;

        /// Determine the rating based on the difference between the actual value and the ideal.
        if (_difference <= 10)
        {
            _rating = 5;
        }
        else if (_difference <= 15)
        {
            _rating = 4;
        }
        else if (_difference <= 20)
        {
            _rating = 3;
        }
        else if (_difference <= 25)
        {
            _rating = 2;
        }
        else
        {
            _rating = 1;
        }

        /// Return the calculated rating.
        return _rating;
    }

    /// <summary>
    /// Calculate and store the ratings for each of the rated values, then call EndRatingsDisplayManager to display the ratings.
    /// </summary>
    public void CalculateEndRatings()
    {
        /// Calculate the rating for Wall Saturation.
        WallSaturationRating = CalculateRating(m_idealWallSaturation, m_coreAlgorithm.MoistureModel.WallSaturation);

        /// Calculate the rating for Air Saturation.
        AirSaturationRating = CalculateRating(m_idealAirSaturation, m_coreAlgorithm.MoistureModel.AirSaturation);

        /// Calculate the rating for Money Spent.
        MoneySpentRating = CalculateRating(m_idealMondaySpent, m_coreAlgorithm.MoneyModel.MoneySpent);

        /// Debug statements.
        Debug.Log("Ratings - Wall Sat: " + WallSaturationRating + " - Air Sat: " + AirSaturationRating + " - Money Spent: " + MoneySpentRating);

        /// Call EndRatingsDisplayManger to display the correct number of icons according to the calculated ratings.
        m_endRatingsDisplayManager.DisplayRatings();
    }
}

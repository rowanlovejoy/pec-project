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
    /// Divisor used to calculate the quotient that determines the wall saturation rating.
    /// </summary>
    [SerializeField]
    private float m_wallSaturationDivisor = 5;

    /// <summary>
    /// Divisor used to calculate the quotient that determines the air saturation rating.
    /// </summary>
    [SerializeField]
    private float m_airSaturationDivisor = 5;

    /// <summary>
    /// Divisor used to calculate the quotient that determines the money spent rating.
    /// </summary>
    [SerializeField]
    private float m_moneySpentDivisor = 5;

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
    /// Calculate the rating for a given final value.
    /// </summary>
    /// <param name="finalValue">The final value to be rated.</param>
    /// <param name="_divisor">The divisor used with the final value to calculate the quotient that determines the rating.</param>
    /// <returns>The calculated rating for the given final value.</returns>
    private int CalculateRating(int _finalValue, float _divisor)
    {
        /// Calculate the quotient of the final value being rated divided by the divisor value.
        float _quotient = _finalValue / _divisor;
        Debug.Log("Final value: " + _finalValue + " / " + _divisor + ": " + _quotient);

        /// Variable to store the calculated rating.
        int _rating = 0;

        /// Determine the rating based on the quotient.
        if (_quotient <= 2)
        {
            _rating = 1;
        }
        else if (_quotient <= 3)
        {
            _rating = 2;
        }
        else if (_quotient <= 4)
        {
            _rating = 3;
        }
        else if (_quotient <= 5)
        {
            _rating = 4;
        }
        else
        {
            _rating = 5;
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
        WallSaturationRating = CalculateRating(m_coreAlgorithm.MoistureModel.WallSaturation, m_wallSaturationDivisor);

        /// Calculate the rating for Air Saturation.
        AirSaturationRating = CalculateRating(m_coreAlgorithm.MoistureModel.AirSaturation, m_airSaturationDivisor);

        /// Calculate the rating for Money Spent.
        MoneySpentRating = CalculateRating(m_coreAlgorithm.MoneyModel.MoneySpent, m_moneySpentDivisor);

        /// Debug statements.
        Debug.Log("Ratings - Wall Sat: " + WallSaturationRating + " - Air Sat: " + AirSaturationRating + " - Money Spent: " + MoneySpentRating);

        /// Call EndRatingsDisplayManger to display the correct number of icons according to the calculated ratings.
        m_endRatingsDisplayManager.DisplayRatings();
    }
}

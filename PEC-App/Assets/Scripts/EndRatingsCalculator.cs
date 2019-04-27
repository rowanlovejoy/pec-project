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
    /// Range used to calculate the quotient that determines the money spent rating.
    /// </summary>
    [SerializeField]
    private float m_moneySpentRange = 5;

    /// <summary>
    /// Minimum used to calculate the quotient that determines the money spent rating.
    /// </summary>
    [SerializeField]
    private float m_moneySpentMinimum = 5;

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
    /// Calculate the rating for a given final value using minimum and range.
    /// </summary>
    /// <param name="_finalValue">The final value to be rated.</param>
    /// <param name="_range">The range used with the final value to calculate the quotient that determines the rating.</param>
    /// <returns>The calculated rating for the given final value.</returns>
    private int CalculateRangedRating(float _finalValue, float _minimum, float _range)
    {
        float _quotient = (_finalValue - _minimum) / _range;
        Debug.Log("Final value: (" + _finalValue + " - " + _minimum + ") / " + _range + ": " + _quotient);

        /// Variable to store the calculated rating.
        int _rating = 0;

        /// Determine the rating based on the quotient.
        if (_quotient < 0.2f)
        {
            _rating = 1;
        }
        else if (_quotient < 0.4f)
        {
            _rating = 2;
        }
        else if (_quotient < 0.6f)
        {
            _rating = 3;
        }
        else if (_quotient < 0.8f)
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
    /// Calculate the cost rating using the initial temperature selections.
    /// </summary>
    /// <param name="_heatingPeriodSetting">Index of selected heating period.</param>
    /// <param name="_thermostatSetting">Index of selected thermostat setting.</param>
    /// <returns>The calculated cost rating.</returns>
    private int CalculateCostRating(int _heatingPeriodSetting, int _thermostatSetting, int _ventilationSetting)
    {
        /// Sum all user selections
        int _total = _heatingPeriodSetting + _thermostatSetting + _ventilationSetting;

        /// Variable to store the calculated rating.
        int _rating = 0;

        /// Use of sum of selected setting indices to determine rating.
        switch (_total)
        {
            case 0:
                _rating = 1;
                break;
            case 1:
                _rating = 1;
                break;
            case 2:
                _rating = 2;
                break;
            case 3:
                _rating = 3;
                break;
            case 4:
                _rating = 4;
                break;
            case 5:
                _rating = 5;
                break;
            case 6:
                _rating = 5;
                break;
            default:
                break;
        }

        return _rating;
    }

    /// <summary>
    /// Calculate and store the ratings for each of the rated values, then call EndRatingsDisplayManager to display the ratings.
    /// </summary>
    public void CalculateEndRatings()
    {
        /// Calculate the rating for Wall Saturation. Minimum wall saturation will always be 0 and range will always be 100
        WallSaturationRating = CalculateRangedRating(m_coreAlgorithm.MoistureModel.WallSaturation, 0f, 100f);

        /// Calculate the rating for Air Saturation. Minimum air saturation will always be 50 and range will always be 50.
        AirSaturationRating = CalculateRangedRating(m_coreAlgorithm.MoistureModel.AirSaturation, 50f, 50f);

        /// Calculate the rating for Money Spent.
        MoneySpentRating = CalculateCostRating(m_coreAlgorithm.TemperatureModel.HeatingPeriodSelection, m_coreAlgorithm.TemperatureModel.ThermostatSettingSelection, m_coreAlgorithm.MoistureModel.MoistureRemovalSelection);

        /// Debug statements.
        Debug.Log("Ratings - Wall Sat: " + WallSaturationRating + " - Air Sat: " + AirSaturationRating + " - Money Spent: " + MoneySpentRating);

        /// Call EndRatingsDisplayManger to display the correct number of icons according to the calculated ratings.
        m_endRatingsDisplayManager.DisplayRatings();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRatingsDisplayManager : MonoBehaviour
{
    /// <summary>
    /// Reference to EndRatingsCalculator.
    /// </summary>
    [SerializeField]
    private EndRatingsCalculator m_endRatingsCalculator = null;

    /// <summary>
    /// Rating icons for the wall saturation end rating;
    /// </summary>
    [SerializeField]
    private GameObject[] m_wallSaturationRatingIcons;

    /// <summary>
    /// Rating icons for the air saturation end rating.
    /// </summary>
    [SerializeField]
    private GameObject[] m_airSaturationRatingIcons;

    /// <summary>
    /// Rating icons for the money spent end rating.
    /// </summary>
    [SerializeField]
    private GameObject[] m_moneySpentRatingIcons;

    /// <summary>
    /// Display the correct number of icons for the provided rating.
    /// </summary>
    /// <param name="_rating">The rating to display icons for.</param>
    /// <param name="_ratingIconsSet">The set of icons used to display the rating.</param>
    private void DisplayRatingIcons(int _rating, GameObject[] _ratingIconsSet)
    {
        /// Check that rating icon objects have been set.
        if (_ratingIconsSet != null)
        {
            /// Display the correct number of icons for the rating.
            for (int i = 0; i < _rating; i++)
            {
                _ratingIconsSet[i].SetActive(true);
            }
        }
        /// Log an error if no rating icons have been set.
        else
        {
            Debug.Log("Incorrect number of rating icons.");
        }
    }

    /// <summary>
    /// Display the correct number of icons for each rating.
    /// </summary>
    public void DisplayRatings()
    {
        /// Display icons for the Wall Saturation rating.
        DisplayRatingIcons(m_endRatingsCalculator.WallSaturationRating, m_wallSaturationRatingIcons);

        /// Display icons for the Air Saturation rating.
        DisplayRatingIcons(m_endRatingsCalculator.AirSaturationRating, m_airSaturationRatingIcons);

        /// Display icons for the Money Spent rating.
        DisplayRatingIcons(m_endRatingsCalculator.MoneySpentRating, m_moneySpentRatingIcons);
    }
}

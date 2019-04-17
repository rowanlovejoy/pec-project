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
        /// Stores how many icons in the given set are already displayed.
        int _visibleIcons = 0;

        /// Check that rating icon objects have been set.
        if (_ratingIconsSet != null)
        {
            /// Display the correct number of icons for the rating.
            for (int i = 0; i < _ratingIconsSet.Length; i++)
            {
                /// If the correct number of icons are not already displayed, display more.
                if (_visibleIcons < _rating)
                {
                    _ratingIconsSet[i].SetActive(true);
                    _visibleIcons++;
                }
                /// If the correct number of icons are already display, hide the remaining icons in the set.
                else
                {
                    _ratingIconsSet[i].SetActive(false);
                }
            }

            Debug.Log("Displayed " + _rating + " icons of set");
        }
        /// Log an error if no rating icons have been set.
        else
        {
            Debug.LogError("Incorrect number of rating icons.");
        }
    }

    /// <summary>
    /// Hides all rating icons in the given set, effectively resetting the display.
    /// </summary>
    /// <param name="_ratingIconSet">The set of rating icons to hide.</param>
    private void ResetDisplayedIcons(GameObject[] _ratingIconSet)
    {
        for (int i = 0; i < _ratingIconSet.Length; i++)
        {
            _ratingIconSet[i].SetActive(false);
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

    /// <summary>
    /// Hides all displayed rating icons.
    /// </summary>
    public void ResetDisplayedRatings()
    {
        /// Hide icons for the Wall Saturation rating.
        ResetDisplayedIcons(m_wallSaturationRatingIcons);

        /// Hides icons for the Air Saturation rating.
        ResetDisplayedIcons(m_airSaturationRatingIcons);

        /// Hides icons for the Money Spent rating.
        ResetDisplayedIcons(m_moneySpentRatingIcons);
    }
}

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

    private void DisplayRatingIcons(int _rating, GameObject[] _ratingIconsSet)
    {
        if (_rating == _ratingIconsSet.Length)
        {
            for (int i = 0; i < _rating; i++)
            {
                _ratingIconsSet[i].SetActive(true);
            }
        }
        else
        {
            Debug.Log("Incorrect number of rating icons.");
        }
    }

    public void DisplayRatings()
    {
        DisplayRatingIcons(m_endRatingsCalculator.WallSaturationRating, m_wallSaturationRatingIcons);

        DisplayRatingIcons(m_endRatingsCalculator.AirSaturationRating, m_airSaturationRatingIcons);

        DisplayRatingIcons(m_endRatingsCalculator.MoneySpentRating, m_moneySpentRatingIcons);
    }
}

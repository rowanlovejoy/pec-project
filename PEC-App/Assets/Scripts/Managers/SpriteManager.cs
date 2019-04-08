using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    /// <summary>
    /// Reference to array of gameobjects that group sprites into low, medium and high
    /// </summary>
    [SerializeField]
    private GameObject[] m_moistureSpriteGroups;

    /// <summary>
    /// Reference to array of gameobjects that group sprites into low, medium and high
    /// </summary>
    [SerializeField]
    private GameObject[] m_ventilationSpriteGroups;

    void Start()
    {
        /// initialize setting to minimum
        ResetSprites(); 
    }

    /// <summary>
    /// Enables a group of sprites related to ventilation and hides any that aren't selected
    /// </summary>
    /// <param name="_selection">The selection made by the user. An integer between 0 and 2 (inclusive).</param>
    public void UpdateVentilationSprites(int _selection)
    {
        /// error handling
        if (m_ventilationSpriteGroups.Length <= _selection || _selection < 0) 
        {
            Debug.LogError("Selection made is out of bounds of array.");
        }
        else
        {
            for (int i = 0; i < m_ventilationSpriteGroups.Length; i++)
            {
                /// if group has been selected
                if (i == _selection) 
                {
                    /// enable (show) group
                    m_ventilationSpriteGroups[i].SetActive(true); 
                }
                /// if group has not been selected
                else
                {
                    /// disable (hide) group
                    m_ventilationSpriteGroups[i].SetActive(false);
                }
            }
        }
    }

    /// <summary>
    /// Enables a group of sprites related to moisture production and hides any that aren't selected
    /// </summary>
    /// <param name="_selection">The selection made by the user. An integer between 0 and 2 (inclusive).</param>
    public void UpdateMoistureProductionSprites(int _selection)
    {
        /// error handling
        if (m_moistureSpriteGroups.Length <= _selection || _selection < 0) 
        {
            Debug.LogError("Selection made is out of bounds of array.");
        }
        else
        {
            for (int i = 0; i < m_moistureSpriteGroups.Length; i++)
            {
                /// if group has been selected
                if (i == _selection) 
                {
                    /// enable (show) group
                    m_moistureSpriteGroups[i].SetActive(true); 
                }
                /// if group has not been selected
                else
                {
                    /// disable (hide) group
                    m_moistureSpriteGroups[i].SetActive(false); 
                }
            }
        }
    }

    /// <summary>
    /// Resets graphics to lowest selection.
    /// </summary>
    public void ResetSprites()
    {
        UpdateMoistureProductionSprites(0);
        UpdateVentilationSprites(0);
    }
}

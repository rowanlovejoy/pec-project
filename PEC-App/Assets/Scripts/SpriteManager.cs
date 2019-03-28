using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_moistureSpriteGroups;

    [SerializeField]
    private GameObject[] m_ventilationSpriteGroups;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // FOR TESTING PURPOSES, DELETE LATER
        {
            UpdateMoistureProductionSprites(0);
            UpdateVentilationSprites(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // FOR TESTING PURPOSES, DELETE LATER
        {
            UpdateMoistureProductionSprites(1); 
            UpdateVentilationSprites(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))// FOR TESTING PURPOSES, DELETE LATER
        {
            UpdateMoistureProductionSprites(2);
            UpdateVentilationSprites(2);
        }
    }

    /// <summary>
    /// Enables a group of sprites related to ventilation and hides any that aren't selected
    /// </summary>
    /// <param name="selection">The selection made by the user. An integer between 0 and 2 (inclusive).</param>
    public void UpdateVentilationSprites(int selection)
    {
        if (m_ventilationSpriteGroups.Length >= selection || selection < 0) // error handling
        {
            Debug.LogError("Selection made is out of bounds of array.");
        }
        else
        {
            for (int i = 0; i < m_ventilationSpriteGroups.Length; i++)
            {
                if (i == selection) // if group has been selected
                {
                    m_ventilationSpriteGroups[selection].SetActive(true); // enable (show) group
                }
                else // if group has not been selected
                {
                    m_ventilationSpriteGroups[selection].SetActive(false); // disable (hide) group
                }
            }
        }
    }

    /// <summary>
    /// Enables a group of sprites related to moisture production and hides any that aren't selected
    /// </summary>
    /// <param name="selection">The selection made by the user. An integer between 0 and 2 (inclusive).</param>
    public void UpdateMoistureProductionSprites(int selection)
    {
        if (m_moistureSpriteGroups.Length >= selection || selection < 0) // error handling
        {
            Debug.LogError("Selection made is out of bounds of array.");
        }
        else
        {
            for (int i = 0; i < m_moistureSpriteGroups.Length; i++)
            {
                if (i == selection) // if group has been selected
                {
                    m_moistureSpriteGroups[selection].SetActive(true); // enable (show) group
                }
                else // if group has not been selected
                {
                    m_moistureSpriteGroups[selection].SetActive(false); // disable (hide) group
                }
            }
        }
    }
}

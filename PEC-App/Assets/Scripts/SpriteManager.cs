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


}

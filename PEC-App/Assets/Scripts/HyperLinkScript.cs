﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperLinkScript : MonoBehaviour
{
    /// <summary>
    /// Opens the Plymouth Energy Community Website when the method fires
    /// </summary>
public void PECSite()
    {
        Application.OpenURL("https://www.plymouthenergycommunity.com/help/tips");

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ParamHelpTextManager : MonoBehaviour
{
    /// <summary>
    /// Array to store help text for each parameter.
    /// </summary>
    [SerializeField, TextArea(3, 10)]
    private string[] m_paramText = null;
}

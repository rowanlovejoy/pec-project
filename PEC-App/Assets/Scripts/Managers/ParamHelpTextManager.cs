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

    /// <summary>
    /// The currently displayed parameter help text.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI m_textDisplay = null;

    /// <summary>
    /// Displays the selected text on Parameter Help screen.
    /// </summary>
    /// <param name="_textIndex">The index at which the selected text is stored.</param>
    public void DisplayHelpText(int _textIndex)
    {
        m_textDisplay.text = m_paramText[_textIndex];
    }
}

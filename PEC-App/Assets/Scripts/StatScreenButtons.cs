using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatScreenButtons : MonoBehaviour
{
    /// <summary>
    /// To check whether the panel is currently visible.
    /// </summary>
    private bool m_isVisible = false;

    /// <summary>
    /// A reference to an animator component.
    /// </summary>
    private Animator m_animator;

    /// <summary>
    /// Gets the animator component from the attached GameObject.
    /// </summary>
    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    /// <summary>
    /// On button press, check if panel is visible, if it isn't, slide in, otherwise, slide out.
    /// </summary>
    public void OnBtnClick()
    {
        if (!m_isVisible)
        {
            m_animator.SetTrigger("DoSlideInAnimation");
            m_isVisible = true;
        }
        else
        {
            m_animator.SetTrigger("DoSlideOutAnimation");
            m_isVisible = false;
        }
    }
}

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
        if (m_isVisible == false)
        {
            m_animator.SetTrigger("DoSlideInAnimation");
            m_isVisible = true;
        }
        else 
        {
            EndSimEvent();
        }
    }

    /// <summary>
    /// A method that's called when the End Screen Event occurs.
    /// </summary>
    public void EndSimEvent()
    {
        if (m_isVisible == true)
        {
            m_animator.SetTrigger("DoSlideOutAnimation");
            m_isVisible = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// The code in this script is based on that provided in a publicly available YouTube video tutorial created by user Indie Nuggets (2018). 
/// For a full reference to this tutorial, and others used during the creation of this project, 
/// see the document Third-Party Asset and Code Declaration – Plymouth Energy Community Project.

/// <summary>
/// Creates an event listener that can invoke a response when it's raised
/// </summary>
public class EventListener : MonoBehaviour
{
    /// <summary>
    ///  A reference to an event
    /// </summary>
    [SerializeField]
    private GameEvent m_event = null;

    /// <summary>
    /// A reference to the response to an event
    /// </summary>
    [SerializeField]
    private UnityEvent m_response = null;
        
    /// <summary>
    /// Adds  the event in the eventListener list // Calls the Register method found in GameEvent
    /// </summary>
    private void OnEnable()
    {
        m_event.Register(this);
    }

    /// <summary>
    /// Removes the event from the eventListener list // Calls the DeRegister method found in GameEvent
    /// </summary>
    private void OnDisable()
    {
        m_event.DeRegister(this);
    }

    /// <summary>
    /// Invokes the relevant response for an event
    /// </summary>
    public void OnEventRaised()
    {
        m_response.Invoke();
    }
}

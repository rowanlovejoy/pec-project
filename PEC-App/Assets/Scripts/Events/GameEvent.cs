﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// The code in this script is based on that provided in a publicly available YouTube video tutorial created by user Indie Nuggets (2018). 
/// For a full reference to this tutorial, and others used during the creation of this project, 
/// see the document Third-Party Asset and Code Declaration – Plymouth Energy Community Project.

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    /// <summary>
    ///  A list of all registered EventListeners
    /// </summary>
    private List<EventListener> m_eventListeners = new List<EventListener>();

    /// <summary>
    /// Raises the events even listener and calls its responses
    /// </summary>
    public void Raise()
    {
        for (int i = 0; i < m_eventListeners.Count; i++)
        {
            m_eventListeners[i].OnEventRaised();
        }
    }

    /// <summary>
    /// Adds a listener to the EventListener list
    /// </summary>
    /// <param name="_listener"></param>
    public void Register(EventListener _listener)
    {
        if (!m_eventListeners.Contains(_listener))
        {
            m_eventListeners.Add(_listener);
        }
    }

    /// <summary>
    ///  Removes a listener from the EventListener list
    /// </summary>
    /// <param name="_listener"></param>
    public void DeRegister(EventListener _listener)
    {
        if (m_eventListeners.Contains(_listener))
        {
            m_eventListeners.Remove(_listener);
        }
    }
}

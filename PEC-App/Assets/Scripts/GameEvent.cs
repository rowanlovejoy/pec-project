﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Master
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        [SerializeField]
        private List<EventListener> m_eventListeners = new List<EventListener>();

        public void Raise()
        {
            for (int i = 0; i < m_eventListeners.Count; i++)
            {

            }
        }

        public void Register(EventListener _listener)
        {
            if (!m_eventListeners.Contains(_listener))
            {
                m_eventListeners.Add(_listener);
            }
        }
    }
}

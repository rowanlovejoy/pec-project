using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Master
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        /// <summary>
        /// 
        /// </summary>

        private List<EventListener> m_eventListeners = new List<EventListener>();
        /// <summary>
        /// 
        /// </summary>
        public void Raise()
        {
            for (int i = 0; i < m_eventListeners.Count; i++)
            {
                m_eventListeners[i].OnEventRaised();
            }
        }
        /// <summary>
        /// 
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
        /// 
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
}

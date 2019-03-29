using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Master
{
    public class EventListener : MonoBehaviour
    {/// <summary>
    /// 
    /// </summary>
        [SerializeField]
        private UnityEvent m_response = null;
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        private GameEvent m_event = null;

        /// <summary>
        /// 
        /// </summary>
        private void OnEnable()
        {
            m_event.Register(this);
        }
        /// <summary>
        /// 
        /// </summary>
        private void OnDisable()
        {
            m_event.DeRegister(this);
        }
        /// <summary>
        /// 
        /// </summary>
        public void OnEventRaised()
        {
            m_response.Invoke();
        }
    }
}
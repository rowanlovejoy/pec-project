using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Master
{
    public class EventListener : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent m_response;

        [SerializeField]
        private GameEvent m_event;

        private void OnEnable()
        {
            m_event.Register(this);
        }

        private void OnDisable()
        {
            m_event.Register(this);
        }

        public void OnEventRaised()
        {
            m_response.Invoke();
        }
    }
}
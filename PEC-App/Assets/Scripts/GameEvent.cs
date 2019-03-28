using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Master
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        [SerializeField]
        private List<EventListener> m_eventListeners = new List<EventListener>();
    }
}

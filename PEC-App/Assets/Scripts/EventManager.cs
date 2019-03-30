using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Master
{
    /// <summary>
    /// Creates a custom menu button "Raise"
    /// </summary>
    [CustomEditor(typeof(GameEvent))]
    public class EventManager : Editor
    {
        /// <summary>
        /// overrides the default OnInspectorGUI to enable the "Raise" button when the scene is in play mode
        /// </summary>
        public override void OnInspectorGUI()
        {
            ///implements base class functionality
            base.OnInspectorGUI();
            ///if the application is playing, the GUI is enabled
            GUI.enabled = Application.isPlaying;

            ///sets _event as the target
            GameEvent _event = target as GameEvent;

            ///on pressing the button, raise the event
            if (GUILayout.Button("Raise"))
            {
                _event.Raise();
            }
        }
    }
}

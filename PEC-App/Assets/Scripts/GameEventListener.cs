using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Master
{

    [CustomEditor(typeof(GameEvent))]
    public class GameEventListener : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUI.enabled = Application.isPlaying;

            GameEvent _event = target as GameEvent;

            if (GUILayout.Button("Raise"))
            {
                _event.Raise();
            }
        }


    }

}

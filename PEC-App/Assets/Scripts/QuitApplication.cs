using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    /// <summary>
    /// Quits the application when not in editor mode when called.
    /// </summary>
    public void QuitApplicationBtn()
    {
        ///Quits the application.
        Application.Quit();

        ///For testing in Unity Editor only.
        #if (UNITY_EDITOR)
        Debug.Log("Application would have been closed, if you were in a build of the project.");
        #endif
    }
}

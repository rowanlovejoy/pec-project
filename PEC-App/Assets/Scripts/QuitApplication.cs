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
        Application.Quit();
    }

}

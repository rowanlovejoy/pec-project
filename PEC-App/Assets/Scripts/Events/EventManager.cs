using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance = null;

    /// <summary>
    /// Method called before Start function
    /// </summary>
    void Awake()
    {
        /// if instance does not already exist
        if (instance == null)
        {
            instance = this;
        }
        /// else if another instance already exists that is not this gameobject
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}

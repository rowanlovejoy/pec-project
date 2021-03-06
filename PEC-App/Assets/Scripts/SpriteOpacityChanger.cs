﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteOpacityChanger : MonoBehaviour
{
    /// <summary>
    /// The reference to the sprite renderer attached to this gameobject.
    /// </summary>
    private SpriteRenderer m_sprite = null;

    /// <summary>
    /// A temporary colour variable used to adjust the sprite colour.
    /// </summary>
    private Color m_tempColour;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    private void Start()
    {
        m_sprite = GetComponent<SpriteRenderer>();
        m_tempColour = m_sprite.color;
    }

    /// <summary>
    /// Calls coroutine that starts opacity transition.
    /// </summary>
    /// <param name="_opacityValue">A value between 0-1 that represents the new opacity value.</param>
    private void ChangeOpacity(float _opacityValue)
    {
        /// If the new opacity is not approximately the same as the current opacity.
        if (!Mathf.Approximately(m_sprite.color.a, _opacityValue))
        {
            StopAllCoroutines();

            StartCoroutine(LerpAlpha(_opacityValue));
        }
    }

    /// <summary>
    /// A coroutine that lerps the opacity of a sprite between its current opacity and a target opacity.
    /// </summary>
    /// <param name="_targetOpacity">The target opacity. A value between 0-1.</param>
    /// <returns></returns>
    IEnumerator LerpAlpha(float _targetOpacity)
    {
        /// While the actual opacity is not the target opacity.
        while (m_sprite.color.a != _targetOpacity)
        {
            /// Lerp the alpha a fifth towards the target opacity.
            m_tempColour.a = Mathf.Lerp(m_sprite.color.a, _targetOpacity, 0.2f);
            m_sprite.color = m_tempColour;
            yield return null;
        }
    }

    /// <summary>
    /// Sets the opacity of the sprite to transparent (0).
    /// </summary>
    public void ResetOpacity()
    {
        StopAllCoroutines();
        m_tempColour.a = 0f;
        m_sprite.color = m_tempColour;
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        /// Subscribe to the OnSendWallSation event.
        MoistureModel.OnSendWallSaturation += ChangeOpacity;
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled.
    /// </summary>
    private void OnDisable()
    {
        /// Unsubscribe to the OnSendWallSation event.
        MoistureModel.OnSendWallSaturation -= ChangeOpacity;
    }
}

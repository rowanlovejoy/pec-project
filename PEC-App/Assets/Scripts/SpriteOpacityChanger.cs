﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteOpacityChanger : MonoBehaviour
{
    private SpriteRenderer m_sprite = null;

    private Color m_tempColour;

    // Start is called before the first frame update
    void Start()
    {
        m_sprite = GetComponent<SpriteRenderer>();
        m_tempColour = m_sprite.color;
    }

    public void ChangeOpacity(float _newValue)
    {
        StartCoroutine(LerpAlpha(_newValue));
    }

    IEnumerator LerpAlpha(float _targetValue)
    {
        while (m_tempColour.a != _targetValue)
        {
            m_tempColour.a = Mathf.Lerp(m_sprite.color.a, _targetValue, 1f);
            m_sprite.color = m_tempColour;
            yield return null;
        }
    }
}

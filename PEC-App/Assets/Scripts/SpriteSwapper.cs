using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SpriteSwapper : MonoBehaviour
{
    private Image m_image = null;

    private Sprite m_originalSprite = null;

    [SerializeField]
    private Sprite m_newSprite;

    private bool m_isOriginalSprite = true;

    // Start is called before the first frame update
    private void Start()
    {
        m_image = GetComponent<Image>();

        m_originalSprite = m_image.sprite;
    }

    public void SwapSprites()
    {
        if (m_isOriginalSprite)
        {
            m_image.sprite = m_newSprite;
            m_isOriginalSprite = false;
        }
        else
        {
            m_image.sprite = m_originalSprite;
            m_isOriginalSprite = true;
        }
    }
}

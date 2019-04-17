using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SpriteSwapper : MonoBehaviour
{
    /// <summary>
    /// Reference to Image component attached to this gameobject.
    /// </summary>
    private Image m_image = null;

    /// <summary>
    /// Reference to default sprite set in Image component.
    /// </summary>
    private Sprite m_defaultSprite = null;

    /// <summary>
    /// Reference to new image sprite.
    /// </summary>
    [SerializeField]
    private Sprite m_newSprite;

    /// <summary>
    /// Boolean that determines state of sprite.
    /// </summary>
    private bool m_isDefaultSprite = true;

    /// Start is called before the first frame update
    private void Start()
    {
        m_image = GetComponent<Image>();

        m_defaultSprite = m_image.sprite;
    }

    /// <summary>
    /// Swaps sprites between a default sprites and a new sprite.
    /// </summary>
    public void SwapSprites()
    {
        if (m_isDefaultSprite)
        {
            m_image.sprite = m_newSprite;
            m_isDefaultSprite = false;
        }
        else
        {
            m_image.sprite = m_defaultSprite;
            m_isDefaultSprite = true;
        }
    }
}

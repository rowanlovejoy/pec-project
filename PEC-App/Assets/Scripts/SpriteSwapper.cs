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

    // Start is called before the first frame update
    private void Start()
    {
        m_image = GetComponent<Image>();

        m_originalSprite = m_image.sprite;
    }
}

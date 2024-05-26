using System.Collections.Generic;
using UnityEngine;

public class SpriteBackground : MonoBehaviour
{
    [Header("Sprite Component")]
    public SpriteRenderer spriteRenderer;

    [Header("Parameters")]
    public List<Sprite> spriteArray;

    void SetSprite()
    {
        spriteRenderer.sprite = spriteArray[Random.Range(0, spriteArray.Count)];
    }

    private void Awake()
    {
        SetSprite();
    }
  
}

using System;
using UnityEngine;

using Random = Unity.Mathematics.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomTexture : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (sprites == null)
            throw new ArgumentNullException(nameof(sprites));

        spriteRenderer.sprite = PickRandomSprite();
    }


    private Sprite PickRandomSprite()
    {
        var rand = new Random((uint)DateTime.Now.Ticks);

        return sprites[rand.NextInt(0, sprites.Length)];
    }
}

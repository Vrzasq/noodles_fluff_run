using Assets.scripts;
using System;
using UnityEngine;

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


    private Sprite PickRandomSprite() =>
        sprites[Rng.NextInt(0, sprites.Length)];
}

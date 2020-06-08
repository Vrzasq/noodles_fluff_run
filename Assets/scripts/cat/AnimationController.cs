using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    Animator animator;
    [SerializeField] Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        if (rigidbody2D == null)
            throw new ArgumentNullException(nameof(rigidbody2D));

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        SetSpriteOrientation();
    }

    void FixedUpdate()
    {
        animator.SetFloat("speed", Mathf.Abs(rigidbody2D.velocity.x));
    }

    void SetSpriteOrientation()
    {
        if (rigidbody2D.velocity.x < 0)
            spriteRenderer.flipX = true;
        else if (rigidbody2D.velocity.x > 0)
            spriteRenderer.flipX = false;
    }

    public void OnJump()
    {
        animator.SetBool("isJumping", true);
    }

    public void OnLand()
    {
        animator.SetBool("isJumping", false);
    }

}
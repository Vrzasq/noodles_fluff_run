using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    Animator animator;
    [SerializeField] Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        if (rigidbody2D == null)
            rigidbody2D = GetComponentInParent<Rigidbody2D>();
            
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        FlipSprite();
        animator.SetFloat("speed", Mathf.Abs(rigidbody2D.velocity.x));
    }

    void FlipSprite()
    {
        if (rigidbody2D.velocity.x < 0)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }
}
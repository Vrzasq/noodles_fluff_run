using System;
using UnityEngine;

public class ColliderDirection : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2D;

    void Awake()
    {
        if (rigidbody2D == null)
            throw new ArgumentException($"Script is missing {nameof(Rigidbody2D)}");
    }

    void FixedUpdate()
    {
        SetColliderDirection();
    }

    private void SetColliderDirection()
    {
        if (rigidbody2D.velocity.x < 0)
            transform.rotation = new Quaternion(0, 180, 0, 0);
        else if (rigidbody2D.velocity.x > 0)
            transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Transform parentTransorm;
    void Awake()
    {
        rigidBody = GetComponentInParent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        var currentPosition = new Vector2(rigidBody.position.x, rigidBody.position.y);
        rigidBody.MovePosition(currentPosition + (Vector2.right * Time.deltaTime));
    }
}

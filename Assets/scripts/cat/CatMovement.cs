using UnityEngine;

namespace noodles_fluff_run.Assets.scripts.cat
{
    public class CatMovement : MonoBehaviour
    {
        public float force = 7f;
        public Vector2 direction = Vector2.right;
        Rigidbody2D rigidbody2D;


        void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Update()
        {

        }

        void FixedUpdate()
        {
            rigidbody2D.AddForce(direction * force);
        }
    }
}
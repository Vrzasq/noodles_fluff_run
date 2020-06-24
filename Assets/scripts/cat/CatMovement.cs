using UnityEngine;
using UnityEngine.Events;

namespace noodles_fluff_run.Assets.scripts.cat
{
    public class CatMovement : MonoBehaviour
    {
        [SerializeField] private float moveForce = 7f;
        [SerializeField] private float maxSpeed = 3.5f;
        [SerializeField] private float jumpForce = 15f;
        [SerializeField] private Vector2 direction = Vector2.zero;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundMask;

        private Rigidbody2D rigidbody2D;

        private bool shouldJump = false;
        private bool isGrounded = true;

        public UnityEvent Jump;
        public UnityEvent Land;

        void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            RegisterSwipes();
        }

        void FixedUpdate()
        {
            MoveCat();
            CheckGround();

            if (CanJump())
                MakeJump();
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            AirCheck(collision);
        }

        private void MoveCat()
        {
            if (Mathf.Abs(rigidbody2D.velocity.x) < maxSpeed)
                rigidbody2D.AddForce(direction * moveForce);
        }


        private void MakeJump()
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            shouldJump = false;
            isGrounded = false;
            Jump?.Invoke();
        }

        private bool CanJump() => shouldJump && isGrounded;

        private void CheckGround()
        {
            if (isGrounded)
                return;

            if (Physics2D.OverlapBox(groundCheck.position, new Vector2(0.4f, 0.1f), 0, groundMask) != null)
            {
                isGrounded = true;
                Land?.Invoke();
            }
        }

        private void AirCheck(Collision2D collision)
        {
            if (IsGroundLayer(collision.gameObject.layer))
            {
                isGrounded = false;
                Jump?.Invoke();
            }
        }

        private bool IsGroundLayer(int layer) =>
            layer == Mathf.Log(groundMask.value, 2);

        private void RegisterSwipes()
        {
            SwipeEvents.OnSwipeLeft += OnSwipeLeft;
            SwipeEvents.OnSwipeRight += OnSwipRight;
            SwipeManager.OnSingleTap += OnSingleTap;
        }

        private void OnSingleTap()
        {
            if (isGrounded)
                shouldJump = true;
        }


        private void OnSwipeLeft()
        {
            if (direction == Vector2.right)
                direction = Vector2.zero;
            else if (direction == Vector2.zero)
                direction = Vector2.left;
        }

        private void OnSwipRight()
        {
            if (direction == Vector2.left)
                direction = Vector2.zero;
            else if (direction == Vector2.zero)
                direction = Vector2.right;
        }
    }
}
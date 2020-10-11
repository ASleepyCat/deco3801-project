using ScriptableObjects;
using UnityEngine;

namespace MonoBehaviours
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public Rigidbody2D rb;
        public Animator animator;
        
        private PlayerManager _playerManager;
        private Vector2 _movement;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");

        private void Awake()
        {
            _playerManager = PlayerManager.Instance;
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateMovement();
        }

        private void FixedUpdate()
        {
            // Movement Handler
            rb.MovePosition(rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));
        }
        
        private bool CanMove()
        {
            return true;
        }

        private void UpdateMovement()
        {
            if (!CanMove())
            {
                _movement.x = 0;
                _movement.y = 0;
            }
            else
            {
                _movement.x = Input.GetAxisRaw("Horizontal");
                _movement.y = Input.GetAxisRaw("Vertical");
            }
            animator.SetFloat(Horizontal, _movement.x);
            animator.SetFloat(Vertical, _movement.y);
            animator.SetFloat(Speed, _movement.sqrMagnitude);
        }
    }
}

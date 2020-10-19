using ScriptableObjects;
using UnityEngine;

namespace MonoBehaviours
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public Rigidbody2D rb;
        public Animator animator;
        
        private PlayerManager _manager;
        private Vector2 _movement;
        private static readonly int MoveX = Animator.StringToHash("moveX");
        private static readonly int MoveY = Animator.StringToHash("moveY");
        private static readonly int Moving = Animator.StringToHash("moving");
        private static bool _playerExist;

        private void Awake()
        {
            _manager = PlayerManager.instance;
            if (!_playerExist)
            {
                _playerExist = true;
                DontDestroyOnLoad(transform.gameObject);
            }
            else
                Destroy(gameObject);
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
        
        private static bool CanMove()
        {
            return GameManager.Instance.PlayerState.State == PlayerState.States.Free;
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

            if (_movement != Vector2.zero)
            {
                animator.SetFloat(MoveX, _movement.x);
                animator.SetFloat(MoveY, _movement.y);
                animator.SetBool(Moving, true);
            }
            else
                animator.SetBool(Moving, false);
        }
    }
}

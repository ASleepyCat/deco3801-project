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
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");

        private static bool playerExist;

        

        private void Awake()
        {
            _manager = PlayerManager.instance;
           // Start();
            if (!playerExist)
            {
                playerExist = true;
                DontDestroyOnLoad(transform.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            UpdateMovement();
        }

        private void MoveCharacter()
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
            //if (!CanMove())
            //{
            //    _movement.x = 0;
            //    _movement.y = 0;
            //}
            //else
            //{
            //    _movement.x = Input.GetAxisRaw("Horizontal");
            //    _movement.y = Input.GetAxisRaw("Vertical");
            //}
            
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");

            if (_movement != Vector2.zero)
            {
                MoveCharacter();
                animator.SetFloat("moveX", _movement.x);
                animator.SetFloat("moveY", _movement.y);
               // animator.SetFloat(Speed, _movement.sqrMagnitude);
                animator.SetBool("moving", true);
            }
            else
            {
                animator.SetBool("moving", false);
            }
            
            //animator.SetFloat(Horizontal, _movement.x);
            //animator.SetFloat(Vertical, _movement.y);
            
        }
    }
}

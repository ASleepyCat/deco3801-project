using System;
using ScriptableObjects;
using UnityEngine;

namespace MonoBehaviours
{
    public class PlayerMovement : MonoBehaviour
    {

        public float moveSpeed = 5f;
        public Rigidbody2D rb;
        public Animator animator;

        private bool _inventoryOpen = false;
        private Vector2 _movement;
        private InventoryScript _inventory;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");

        private void Awake()
        {
            _inventory = gameObject.AddComponent<InventoryScript>();
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateInventory();
            UpdateMovement();
        }

        private void FixedUpdate()
        {
            // Movement Handler
            rb.MovePosition(rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));
        }

        private void UpdateMovement()
        {
            if (_inventoryOpen) return;
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat(Horizontal, _movement.x);
            animator.SetFloat(Vertical, _movement.y);
            animator.SetFloat(Speed, _movement.sqrMagnitude);
        }

        private void UpdateInventory()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
                _inventoryOpen = !_inventoryOpen;
        }

        private void AddItemToInventory(Item item)
        {
            _inventory.AddItem(item);
        }
    }
}

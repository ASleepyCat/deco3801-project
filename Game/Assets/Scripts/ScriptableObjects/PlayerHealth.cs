using UnityEngine;

namespace ScriptableObjects
{
    public class PlayerHealth : ScriptableObject
    {
        [SerializeField] public int health = 3;

        public delegate void OnHealthDecrement();

        public OnHealthDecrement onHealthDecrementCallback;

        /// <summary>
        /// Decrements <code>health</code> and updates the health UI.
        /// Does nothing if <code>health</code> is already is 0.
        /// </summary>
        public void DecrementHealth()
        {
            if (health <= 0) return;
            --health;
            onHealthDecrementCallback.Invoke();
        }

        /// <summary>
        /// Checks if the player's health is 0.
        /// </summary>
        /// <returns>
        /// Returns true if health is 0, false otherwise.
        /// </returns>
        public bool IsGameOver()
        {
            return health == 0;
        }
    }
}

using ScriptableObjects;
using UnityEngine;

namespace MonoBehaviours
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;
        public PlayerState PlayerState { get; private set; }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of " + GetType().Name + " found!");
                return;
            }
            instance = this;
            PlayerState = ScriptableObject.CreateInstance<PlayerState>();
        }
    }
}

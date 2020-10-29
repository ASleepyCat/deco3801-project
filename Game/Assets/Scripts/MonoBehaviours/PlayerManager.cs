using UnityEngine;

namespace MonoBehaviours
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogWarning("More than one instance of " + GetType().Name + " found!");
                return;
            }
            Instance = this;
        }
    }
}

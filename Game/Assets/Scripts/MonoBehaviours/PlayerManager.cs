using UnityEngine;

namespace MonoBehaviours
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of " + GetType().Name + " found!");
                return;
            }
            instance = this;
        }
    }
}

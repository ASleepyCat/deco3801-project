using UnityEngine;

namespace MonoBehaviours
{
    public class Dialogue : MonoBehaviour
    {
        private static bool _alive;
        
        private void Awake()
        {
            if (!_alive)
            {
                DontDestroyOnLoad(gameObject);
                _alive = true;
            }
            else
                Destroy(gameObject);
        }
    }
}

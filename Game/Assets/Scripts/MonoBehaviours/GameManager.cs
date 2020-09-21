using ScriptableObjects;
using UnityEngine;

namespace MonoBehaviours
{
    public class GameManager : MonoBehaviour
    {
        private Inventory _inventory;

        private void Awake()
        {
            _inventory = ScriptableObject.CreateInstance<Inventory>();
        }
    }
}
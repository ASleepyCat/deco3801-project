using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        public Sprite sprite;
        public string description;
    }
}

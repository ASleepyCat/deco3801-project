using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    public class PlayerHealthBar : MonoBehaviour
    {
        public Transform healthParent;
        
        private PlayerHealth _health;
        private Image[] _points;

        private void Start()
        {
            _health = ScriptableObject.CreateInstance<PlayerHealth>();
            _health.onHealthDecrementCallback = UpdateHealth;
            _points = healthParent.GetComponentsInChildren<Image>();
        }

        private void UpdateHealth()
        {
            _points[_health.health].sprite = null;
            _points[_health.health].enabled = false;
        }
    }
}

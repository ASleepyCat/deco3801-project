using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            if (GameManager.Instance.health != null)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            GameManager.Instance.health = this;
            _health = ScriptableObject.CreateInstance<PlayerHealth>();
            _health.ONHealthDecrementCallback = UpdateHealth;
            _points = healthParent.GetComponentsInChildren<Image>();
            SceneManager.sceneLoaded += ResetHealth;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                _health.DecrementHealth();
        }

        private void UpdateHealth()
        {
            _points[_health.health].enabled = false;
            if (_health.IsGameOver())
            {
                GameManager.Instance.OnPlayerDeath();
                SceneManager.LoadScene("GameOver");   
            }
        }

        private void ResetHealth(Scene scene, LoadSceneMode mode)
        {
            if (!_health.IsGameOver()) return;
            
            _health.health = 3;
            foreach (var health in _points)
                health.enabled = true;
        }
    }
}

using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MonoBehaviours
{
    public class PlayerHealthBar : MonoBehaviour
    {
        public Transform healthParent;
        public delegate void OnPlayerDeath();
        public OnPlayerDeath onPlayerDeathCallback;
        
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
            onPlayerDeathCallback = GameManager.Instance.OnPlayerDeath;
            _health = ScriptableObject.CreateInstance<PlayerHealth>();
            _health.onHealthDecrementCallback = UpdateHealth;
            _points = healthParent.GetComponentsInChildren<Image>();
            SceneManager.sceneLoaded += ResetHealth;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                _health.DecrementHealth();
            if (_health.IsGameOver())
            {
                onPlayerDeathCallback?.Invoke();
                SceneManager.LoadScene("GameOver");   
            }
        }

        private void UpdateHealth()
        {
            _points[_health.health].enabled = false;
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

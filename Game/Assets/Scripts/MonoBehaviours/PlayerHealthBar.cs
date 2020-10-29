using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MonoBehaviours
{
    public class PlayerHealthBar : MonoBehaviour
    {
        public Transform healthParent;
        public bool showHealth;
        
        private PlayerHealth _health;
        private Image[] _points;
        private RectTransform _uiRectTransform;
        // These positions are from the Pos X and Pos Y values in the inspector
        private readonly Vector2 _hide = new Vector2(893, -33.5f); // Off screen
        private readonly Vector2 _show = new Vector2(698.5f, -33.5f);
        private const float Speed = 893 - 698.5f; // Move health bar in one second

        public void HideHealthBar()
        {
            _uiRectTransform.anchoredPosition = _hide;
            showHealth = false;
        }

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
            _uiRectTransform = healthParent.GetComponent<RectTransform>();
        }

        private void Update()
        {
            MoveHealthBar();
        }

        private void MoveHealthBar()
        {
            var position = showHealth ? _show : _hide;
            _uiRectTransform.anchoredPosition = Vector2.MoveTowards(_uiRectTransform.anchoredPosition, 
                position, Speed * Time.deltaTime);
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

        public void ShowPlayerHealth()
        {
            showHealth = true;
        }

        public void ReducePlayerHealth()
        {
            _health.DecrementHealth();
        }

        public void HidePlayerHealth()
        {
            showHealth = false;
        }
    }
}

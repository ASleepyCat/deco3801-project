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

        /// <summary>
        /// Used to reset the position of the health bar on game over.
        /// </summary>
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

        /// <summary>
        /// Moves the position of the health bar's UI element.
        /// </summary>
        private void MoveHealthBar()
        {
            var position = showHealth ? _show : _hide;
            _uiRectTransform.anchoredPosition = Vector2.MoveTowards(_uiRectTransform.anchoredPosition, 
                position, Speed * Time.deltaTime);
        }

        /// <summary>
        /// Updates the health bar UI to hide a health point upon decrementing a health point.
        /// Serves a callback from DecrementHealth().
        /// </summary>
        private void UpdateHealth()
        {
            _points[_health.health].enabled = false;
            if (_health.IsGameOver())
            {
                GameManager.Instance.OnPlayerDeath();
                SceneManager.LoadScene("GameOver");
            }
        }

        /// <summary>
        /// Used to reset health points and health bar when the player reloads from the game over screen.
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="mode"></param>
        private void ResetHealth(Scene scene, LoadSceneMode mode)
        {
            if (!_health.IsGameOver()) return;
            
            _health.health = 3;
            foreach (var health in _points)
                health.enabled = true;
        }

        /// <summary>
        /// Wrapper for dialogue functionality.
        /// </summary>
        public void ShowPlayerHealth()
        {
            showHealth = true;
        }

        /// <summary>
        /// Wrapper for dialogue functionality.
        /// </summary>
        public void ReducePlayerHealth()
        {
            _health.DecrementHealth();
        }

        /// <summary>
        /// Wrapper for dialogue functionality.
        /// </summary>
        public void HidePlayerHealth()
        {
            showHealth = false;
        }
    }
}

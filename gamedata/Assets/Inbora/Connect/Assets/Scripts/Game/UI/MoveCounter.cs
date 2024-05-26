namespace Ilumisoft.Connect.Game
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// UI Behaviour, displaying the number of moves left
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class MoveCounter : MonoBehaviour
    {
        private Text counterText = null;

        private void Awake()
        {
            this.counterText = GetComponent<Text>();
        }

        private void Start()
        {
            UpdateText();
        }

        /// <summary>
        /// Start listening to despawn events
        /// </summary>
        private void OnEnable()
        {
            GameEvents.OnElementsDespawned.AddListener(OnElementsDespawned);
        }

        /// <summary>
        /// Stop listening to despawn events
        /// </summary>
        private void OnDisable()
        {
            GameEvents.OnElementsDespawned.RemoveListener(OnElementsDespawned);
        }

        /// <summary>
        /// Callback which is invoked when bubbles are despawned
        /// </summary>
        /// <param name="count"></param>
        private void OnElementsDespawned(int count)
        {
            UpdateText();
        }

        /// <summary>
        /// Updated the UI text component showing the number of moves left
        /// </summary>
        private void UpdateText()
        {
            this.counterText.text = GameManager.Instance.MovesAvailable.ToString();
        }
    }
}
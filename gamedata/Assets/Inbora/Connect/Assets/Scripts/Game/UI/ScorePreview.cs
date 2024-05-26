namespace Ilumisoft.Connect.Game
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// UI Behaviour, displaying a preview of the score revenue for a selection made by the player
    /// </summary>
    public class ScorePreview : MonoBehaviour
    {
        [SerializeField]
        private Text scorePreviewText = null;
        private float current = 0;

        /// <summary>
        /// Start listening to selection change and despawn events
        /// </summary>
        private void OnEnable()
        {
            GameEvents.OnSelectionChanged.AddListener(OnSelectionChanged);
            GameEvents.OnElementsDespawned.AddListener(OnElementsDespawned);
        }

        /// <summary>
        /// Stop listening to selection change and despawn events
        /// </summary>
        private void OnDisable()
        {
            GameEvents.OnSelectionChanged.RemoveListener(OnSelectionChanged);
            GameEvents.OnElementsDespawned.RemoveListener(OnElementsDespawned);
        }

        private void Start()
        {
            ResetPreview();
        }

        /// <summary>
        /// Callback that is invoked when elements are despawned
        /// </summary>
        /// <param name="count"></param>
        private void OnElementsDespawned(int count)
        {
            ResetPreview();
        }

        /// <summary>
        /// Resets the current preview
        /// </summary>
        private void ResetPreview()
        {
            this.scorePreviewText.text = string.Empty;
            this.current = 0;
        }

        /// <summary>
        /// Callback which is invoked when the selection of the player has changed
        /// </summary>
        /// <param name="count"></param>
        private void OnSelectionChanged(int count)
        {
            if (count > 1)
            {
                int scoreRevenuePreview = count * (count - 1);

                StopAllCoroutines();
                StartCoroutine(UpdateTextCoroutine((int)this.current, scoreRevenuePreview, 0.5f));
            }
            else
            {
                StopAllCoroutines();
                this.scorePreviewText.text = string.Empty;
            }
        }

        /// <summary>
        /// Smoothly updates the text component over the given time
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private IEnumerator UpdateTextCoroutine(int from, int to, float time)
        {
            float currentTime = Time.timeSinceLevelLoad;
            float elapsedTime = 0.0f;
            float lastTime = currentTime;

            while (time > 0 && elapsedTime < time)
            {
                //Update Time
                currentTime = Time.timeSinceLevelLoad;
                elapsedTime += currentTime - lastTime;
                lastTime = currentTime;

                //Update current value
                this.current = Mathf.Lerp(from, to, elapsedTime / time);

                //Update the UI text component
                this.scorePreviewText.text = "+ " + ((int)this.current).ToString();

                yield return null;
            }

            this.scorePreviewText.text = "+ " + to.ToString();
        }
    }
}
namespace Ilumisoft.Connect.Game
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// UI Behaviour, displaying the current score of the player
    /// </summary>
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private Text text = null;

        /// <summary>
        /// Listen to score changed events
        /// </summary>
        private void OnEnable()
        {
            GameEvents.OnScoreChanged.AddListener(OnScoreChanged);
        }

        /// <summary>
        /// Stop listening to score changed events
        /// </summary>
        private void OnDisable()
        {
            GameEvents.OnScoreChanged.RemoveListener(OnScoreChanged);
        }

        /// <summary>
        /// Gets called when the score has been changed
        /// </summary>
        /// <param name="oldScore"></param>
        /// <param name="newScore"></param>
        private void OnScoreChanged(int oldScore, int newScore)
        {
            StopAllCoroutines();
            StartCoroutine(UpdateTextCoroutine(oldScore, newScore, 1.0f));
        }

        /// <summary>
        /// Smoothly updates the score text component over the given time
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

                //Update text component with the interpolated value for the score
                float value = Mathf.Lerp(from, to, elapsedTime / time);
                this.text.text = ((int)value).ToString();

                yield return null;
            }

            this.text.text = to.ToString();
        }
    }
}
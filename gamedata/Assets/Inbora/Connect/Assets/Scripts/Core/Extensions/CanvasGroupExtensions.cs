namespace Ilumisoft.Connect.Core.Extensions
{
    using System.Collections;
    using UnityEngine;

    /// <summary>
    /// Extension classes for the CanvasGroup class
    /// </summary>
    public static class CanvasGroupExtensions
    {
        /// <summary>
        /// A coroutine fading out the CanvasGroup
        /// </summary>
        /// <param name="canvasGroup"></param>
        /// <param name="duration">The duration of the animation in seconds</param>
        /// <returns></returns>
        public static IEnumerator FadeInCoroutine(this CanvasGroup canvasGroup, float duration)
        {
            float process = 0.0f;
            float time = 0.0f;

            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            while (process < 1)
            {
                time += Time.unscaledDeltaTime;

                if (duration <= 0.0f)
                {
                    process = 1.0f;
                }
                else
                {
                    process = Mathf.Clamp01(time / duration);
                }

                canvasGroup.alpha = Mathf.Lerp(0, 1, process);

                yield return null;
            }

            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        /// <summary>
        /// A coroutine fading in the CanvasGroup
        /// </summary>
        /// <param name="canvasGroup"></param>
        /// <param name="duration">The duration of the animation in seconds</param>
        /// <returns></returns>
        public static IEnumerator FadeOutCoroutine(this CanvasGroup canvasGroup, float duration)
        {
            float process = 0.0f;
            float time = 0.0f;

            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            while (process < 1)
            {
                time += Time.unscaledDeltaTime;

                if (duration <= 0.0f)
                {
                    process = 1.0f;
                }
                else
                {
                    process = Mathf.Clamp01(time / duration);
                }

                canvasGroup.alpha = Mathf.Lerp(1, 0, process);

                yield return null;
            }
        }
    }
}
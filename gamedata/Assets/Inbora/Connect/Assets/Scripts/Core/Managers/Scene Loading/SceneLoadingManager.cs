namespace Ilumisoft.Connect.Core
{
    using Ilumisoft.Connect.Core.Extensions;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    /// <summary>
    /// Performs the animated loading of the scenes
    /// </summary>
    public class SceneLoadingManager : SingletonBehaviour<SceneLoadingManager>
    {
        private float fadeDuration = 0.5f;

        /// <summary>
        /// Reference to the canvas group used to fade between scenes
        /// </summary>
        private CanvasGroup CanvasGroup { get; set; }

        protected override void Awake()
        {
            base.Awake();

            //Get the canvas group from this GameObject's children
            this.CanvasGroup = GetComponentInChildren<CanvasGroup>();
        }

        /// <summary>
        /// Loads a scene by the given scene name
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="mode"></param>
        public void LoadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
        {
            StopAllCoroutines();
            StartCoroutine(LoadSceneCoroutine(sceneName, mode));
        }

        /// <summary>
        /// Coroutine smoothly fading to the given scene
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        private IEnumerator LoadSceneCoroutine(string sceneName, LoadSceneMode mode)
        {
            //Fade transition canvas in
            yield return StartCoroutine(this.CanvasGroup.FadeInCoroutine(this.fadeDuration));

            //Load the scene
            SceneManager.LoadScene(sceneName, mode);

            yield return new WaitForSeconds(0.25f);

            //Fade transition canvas out
            yield return StartCoroutine(this.CanvasGroup.FadeOutCoroutine(this.fadeDuration * 1.5f));
        }
    }
}
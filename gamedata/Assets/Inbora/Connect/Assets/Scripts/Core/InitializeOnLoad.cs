namespace Ilumisoft.Connect
{
    using UnityEngine;

    /// <summary>
    /// Contains the logic to automatically initialize all persistent game systems, 
    /// before any scene is loaded.
    /// </summary>

    internal static class InitializeOnLoad
    {
        /// <summary>
        /// Automatically loads and instantiate all GameObjects from the "Resources/InitializeOnLoad" folder.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeApplication()
        {
            GameObject[] prefabs = Resources.LoadAll<GameObject>("Ilumisoft/Connect/InitializeOnLoad/");

            if (prefabs.Length > 0)
            {
                foreach (var prefab in prefabs)
                {
                    GameObject gameObject = Object.Instantiate(prefab);

                    gameObject.name = prefab.name;

                    Object.DontDestroyOnLoad(gameObject);
                }
            }
        }
    }
}
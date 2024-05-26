namespace Ilumisoft.Connect.Game
{
    using Ilumisoft.Connect;
    using Ilumisoft.Connect.Core;
    using Ilumisoft.Connect.Core.UI;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// User interface logic of the settings scene.
    /// </summary>
    public class SettingsUI : UserInterface
    {
        [SerializeField] private Button returnButton = null;

        private void Start()
        {
            this.returnButton.onClick.AddListener(OnBackButtonClick);
        }

        /// <summary>
        /// Returns to the settings scene
        /// </summary>
        protected override void OnBackButtonClick()
        {
            SceneLoadingManager.Instance.LoadScene(SceneNames.Menu);
        }
    }
}
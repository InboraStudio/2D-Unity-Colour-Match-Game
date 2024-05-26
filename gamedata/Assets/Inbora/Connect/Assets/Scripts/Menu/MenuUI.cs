namespace Ilumisoft.Connect.Game
{
    using Ilumisoft.Connect;
    using Ilumisoft.Connect.Core;
    using Ilumisoft.Connect.Core.UI;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// User interface logic of the menu scene.
    /// </summary>
    public class MenuUI : UserInterface
    {
        //Buttons
        [SerializeField] private Button PlayButton = null;
        [SerializeField] private Button HelpButton = null;
        [SerializeField] private Button SettingsButton = null;

        //Highscore text
        [SerializeField] private Text HighscoreText = null;

        private void Start()
        {
            //Listen to button click events
            this.PlayButton.onClick.AddListener(LoadGameScene);
            this.HelpButton.onClick.AddListener(LoadHelpScene);
            this.SettingsButton.onClick.AddListener(LoadSettingsScene);

            //Set highscore text
            this.HighscoreText.text = HighscoreManager.Instance.Highscore.ToString();
        }

        /// <summary>
        /// Loads the game scene
        /// </summary>
        private void LoadGameScene()
        {
            SceneLoadingManager.Instance.LoadScene(SceneNames.Game);
        }

        /// <summary>
        /// Loads the help scene
        /// </summary>
        private void LoadHelpScene()
        {
            SceneLoadingManager.Instance.LoadScene(SceneNames.Help);
        }

        /// <summary>
        /// Loads the settings scene
        /// </summary>
        private void LoadSettingsScene()
        {
            SceneLoadingManager.Instance.LoadScene(SceneNames.Settings);
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        protected override void OnBackButtonClick()
        {
            ExitApplication();
        }

        private void ExitApplication()
        {
            PlayerPrefs.Save();

            Application.Quit();
        }
    }
}
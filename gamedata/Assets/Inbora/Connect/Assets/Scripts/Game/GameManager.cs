namespace Ilumisoft.Connect.Game
{
    using Ilumisoft.Connect;
    using Ilumisoft.Connect.Core;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Handles the game flow
    /// </summary>
    public class GameManager : SingletonBehaviour<GameManager>
    {
        [SerializeField]
        private Button returnButton = null;

        /// <summary>
        /// The score of the player
        /// </summary>
        public static int Score { get; private set; }

        /// <summary>
        /// Reference to the game grid
        /// </summary>
        [SerializeField] private GameGrid grid = null;

        /// <summary>
        /// The number of moves the player has left
        /// </summary>
        [SerializeField] private int movesAvailable = 20;

        /// <summary>
        /// Gets or sets the  number of moves the player has left
        /// </summary>
        public int MovesAvailable
        {
            get => this.movesAvailable;
            set => this.movesAvailable = value;
        }

        /// <summary>
        /// Start listening to relevant events
        /// </summary>
        private void OnEnable()
        {
            GameEvents.OnElementsDespawned.AddListener(OnElementsDespawned);
        }

        //Stop listening from all events
        private void OnDisable()
        {
            GameEvents.OnElementsDespawned.RemoveListener(OnElementsDespawned);
        }

        /// <summary>
        /// Starts and processes the game flow
        /// </summary>
        /// <returns></returns>
        private IEnumerator Start()
        {
            this.returnButton.onClick.AddListener(OnBackButtonClick);

            InitializeGame();

            //Wait for the game to be executed completely
            yield return StartCoroutine(RunGame());

            //Wait for the game to finish
            yield return StartCoroutine(EndGame());
        }

        /// <summary>
        /// Returns to the menu scene
        /// </summary>
        protected void OnBackButtonClick()
        {
            SceneLoadingManager.Instance.LoadScene(SceneNames.Menu);
        }

        /// <summary>
        /// Check for escape button
        /// </summary>
        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                OnBackButtonClick();
            }
        }

        /// <summary>
        /// Initilaizes the game and the grid
        /// </summary>
        public void InitializeGame()
        {
            Score = 0;

            this.grid.SetUpGrid();
        }

        /// <summary>
        /// Runs the game loop
        /// </summary>
        /// <returns></returns>
        public IEnumerator RunGame()
        {
            //Game Loop
            while (this.MovesAvailable > 0)
            {
                //Wait for the Player to select elements
                yield return this.grid.WaitForSelection();

                //Despawn selected elements
                yield return this.grid.DespawnSelection();

                //Wait for the grid elements to finish movement
                yield return this.grid.WaitForMovement();

                //Respawn despawned elements
                yield return this.grid.RespawnElements();
            }
        }

        /// <summary>
        /// Loads the game over scene
        /// </summary>
        /// <returns></returns>
        public IEnumerator EndGame()
        {
            yield return new WaitForSeconds(0.5f);

            SceneLoadingManager.Instance.LoadScene(SceneNames.GameOver);
        }

        /// <summary>
        /// Gets invoked when the user has finished its move and 
        /// the selected elements are despawned
        /// </summary>
        /// <param name="count"></param>
        private void OnElementsDespawned(int count)
        {
            //Update score
            int oldScore = Score;
            Score = oldScore + count * (count - 1);

            //Invoke score changed event
            GameEvents.OnScoreChanged.Invoke(oldScore, Score);
        }
    }
}
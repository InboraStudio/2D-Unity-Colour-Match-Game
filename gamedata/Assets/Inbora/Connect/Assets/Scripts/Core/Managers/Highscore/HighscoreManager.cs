namespace Ilumisoft.Connect.Core
{
    using UnityEngine;

    /// <summary>
    /// Allows other classes to get or set the players highscore
    /// </summary>
    public class HighscoreManager : SingletonBehaviour<HighscoreManager>
    {
        /// <summary>
        /// The player prefs key used to store the highscore
        /// </summary>
        private static readonly string key = "Highscore";

        /// <summary>
        /// Gets or sets the players highscore from the player prefs
        /// </summary>
        public int Highscore
        {
            get
            {
                //Return the highscore from player prefs, if it exists. Zero otherwise
                return PlayerPrefs.HasKey(key) ? PlayerPrefs.GetInt(key) : 0;
            }
            set
            {
                //Store the given value to the player prefs
                PlayerPrefs.SetInt(key, value);
                PlayerPrefs.Save();
            }
        }
    }
}
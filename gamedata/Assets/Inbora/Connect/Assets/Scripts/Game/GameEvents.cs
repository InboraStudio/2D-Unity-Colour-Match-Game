using UnityEngine.Events;

namespace Ilumisoft.Connect.Game
{
    /// <summary>
    /// UnityEvent with integer argument
    /// </summary>
    public class UnityIntEvent : UnityEvent<int> { }

    /// <summary>
    /// UnityEvent with two integer arguments, used to broadcast changes to the score
    /// </summary>
    public class ScoreChangedEvent : UnityEvent<int, int> { }

    /// <summary>
    /// Static class holding all relevant game events
    /// </summary>
    public static class GameEvents
    {
        /// <summary>
        /// Event that is fired when bubbles are despawned
        /// </summary>
        public static UnityIntEvent OnElementsDespawned { get; } = new UnityIntEvent();

        /// <summary>
        /// Event that is fired when the selection of bubbles has changed
        /// </summary>
        public static UnityIntEvent OnSelectionChanged { get; } = new UnityIntEvent();

        /// <summary>
        /// Event that is fired when the score has changed
        /// </summary>
        public static ScoreChangedEvent OnScoreChanged { get; } = new ScoreChangedEvent();
    }
}
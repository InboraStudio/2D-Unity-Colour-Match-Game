namespace Ilumisoft.Connect.Game
{
    using Ilumisoft.Connect.Core;
    using UnityEngine;

    /// <summary>
    /// Singleton class holding all soundeffects used in the game. 
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class GameSFX : SingletonBehaviour<GameSFX>
    {
        /// <summary>
        /// The AudioClip which is played when a selection has been made
        /// </summary>
        [SerializeField]
        public AudioClip SelectionClip;

        /// <summary>
        /// The AudioClip which is played when the selected bubbles are despawned
        /// </summary>
        [SerializeField]
        public AudioClip DespawnClip;

        /// <summary>
        /// The AudioClip which is played when new bubbles are spawned
        /// </summary>
        [SerializeField]
        public AudioClip SpawnClip;

        /// <summary>
        /// Local AudioSource used to play the SelectionClip with different pitches
        /// </summary>
        private AudioSource audioSource;

        /// <summary>
        /// Get all required components
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            this.audioSource = GetComponent<AudioSource>();
        }

        /// <summary>
        /// Plays a given AudioClip
        /// </summary>
        /// <param name="clip"></param>
        public void Play(AudioClip clip)
        {
            SFXManager.Instance.PlayOneShot(clip);
        }

        /// <summary>
        /// Plays a given AudioClip with the given pitch
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="pitch"></param>
        public void Play(AudioClip clip, float pitch)
        {
            //Use the local audioSource to not affect the normal 
            //pitch of other sfx played by the SFXManager
            this.audioSource.pitch = pitch;
            this.audioSource.PlayOneShot(clip);
        }
    }
}
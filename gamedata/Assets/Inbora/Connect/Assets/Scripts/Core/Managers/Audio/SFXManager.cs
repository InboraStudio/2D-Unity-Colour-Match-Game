namespace Ilumisoft.Connect.Core
{
    using UnityEngine;

    /// <summary>
    /// Persistent AudioSystem which can be used to play soundeffects and handles the 
    /// global volume of sfx sounds
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class SFXManager : AudioManager<SFXManager>
    {
        private AudioSource AudioSource { get; set; }

        protected override void Awake()
        {
            base.Awake();

            this.AudioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            LoadSettings();
        }

        /// <summary>
        /// Plays the given AudioClip with the given volume scale (default 1)
        /// </summary>
        /// <param name="clip">The AudioClip which should be played</param>
        /// <param name="volumeScale">The scale of the volume in a range of [0,1]</param>
        public void PlayOneShot(AudioClip clip, float volumeScale = 1.0f)
        {
            this.AudioSource.PlayOneShot(clip, volumeScale);
        }

        /// <summary>
        /// Implementation of the abstract base method, used by the VolumeScale property
        /// of he class
        /// </summary>
        /// <param name="volumeScale"></param>
        protected override void SetVolume(float volumeScale)
        {
            SetVolume("SFX Volume", volumeScale);

            SaveSettings();
        }
    }
}
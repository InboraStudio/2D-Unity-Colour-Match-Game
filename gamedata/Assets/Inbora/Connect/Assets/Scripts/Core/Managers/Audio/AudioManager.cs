namespace Ilumisoft.Connect.Core
{
    using UnityEngine;
    using UnityEngine.Audio;

    /// <summary>
    /// Abstract base class for persistent audio managers, like SFX, Music,...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AudioManager<T> : SingletonBehaviour<T> where T : AudioManager<T>
    {
        [SerializeField]
        private AudioMixer audioMixer = null;
        private float volumeScale = 0.0f;

        /// <summary>
        /// Gets or sets the volume. It is clamped in the range [0,1]
        /// </summary>
        public float VolumeScale
        {
            get => this.volumeScale;

            set
            {
                this.volumeScale = Mathf.Clamp01(value);

                SetVolume(this.volumeScale);
            }
        }

        /// <summary>
        /// Gets the PlayerPrefs key for the volume settings
        /// </summary>
        protected string PlayerPrefsVolumeKey
        {
            //This will return a string in the form "T.Volume" where T is the typeparam
            get => string.Format("{0}.{1}", GetType().Name, "Volume");
        }

        /// <summary>
        /// Sets the volume of the AudioMixer
        /// </summary>
        /// <param name="volumeScale"></param>
        protected abstract void SetVolume(float volumeScale);

        /// <summary>
        /// Sets the volume of the given AudioMixer parameter
        /// </summary>
        /// <param name="volumeParameter"></param>
        /// <param name="volumeScale"></param>
        protected void SetVolume(string volumeParameterName, float volumeScale)
        {
            //Ensure scale is in [0,1]
            volumeScale = Mathf.Clamp01(volumeScale);

            float min = 0.0001f;        //0.0001 equals -80dB
            float max = 1;              //1 equals 0dB

            //Scale volume
            float linearValue = Mathf.Lerp(min, max, volumeScale);

            //Convert volume to decibel
            float dBValue = 20 * Mathf.Log10(linearValue);

            //Set volume
            this.audioMixer.SetFloat(volumeParameterName, dBValue);
        }

        /// <summary>
        /// Saves the volume settings to the PlayerPrefs
        /// </summary>
        public virtual void SaveSettings()
        {
            PlayerPrefs.SetFloat(this.PlayerPrefsVolumeKey, this.VolumeScale);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Loads the volume settings from the PlayerPrefs
        /// </summary>
        protected virtual void LoadSettings()
        {
            if (PlayerPrefs.HasKey(this.PlayerPrefsVolumeKey))
            {
                this.VolumeScale = PlayerPrefs.GetFloat(this.PlayerPrefsVolumeKey);
            }
            else
            {
                this.VolumeScale = 1.0f;
            }
        }
    }
}
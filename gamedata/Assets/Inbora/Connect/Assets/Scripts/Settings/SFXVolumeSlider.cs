namespace Ilumisoft.Connect.Game
{
    using UnityEngine;
    using UnityEngine.UI;
    using Ilumisoft.Connect.Core;

    public class SFXVolumeSlider : MonoBehaviour
    {
        [SerializeField]
        private Slider slider = null;

        [SerializeField]
        private Text valueText = null;

        protected void Start()
        {
            this.slider.onValueChanged.AddListener(OnSliderValueChanged);

            SetSliderValue(SFXManager.Instance.VolumeScale);
            SetValueText(SFXManager.Instance.VolumeScale);
        }

        protected void SetSliderValue(float volumeScale)
        {
            this.slider.value = volumeScale;
        }

        protected void SetValueText(float volumeScale)
        {
            this.valueText.text = ((int)(volumeScale * 100)).ToString() + " %";
        }

        protected void OnSliderValueChanged(float value)
        {
            SFXManager.Instance.VolumeScale = value;

            SetValueText(SFXManager.Instance.VolumeScale);
        }
    }
}
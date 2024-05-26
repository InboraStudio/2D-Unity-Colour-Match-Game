namespace Ilumisoft.Connect.Editor.GameTemplate
{
    using UnityEngine;

    public class PackageInfo : ScriptableObject
    {
        [SerializeField]
        public Texture PackageImage = null;

        [SerializeField]
        public string PackageTitle = string.Empty;

        [SerializeField]
        public string PackageID = string.Empty;

        [SerializeField]
        public Object Documentation = null;

        [SerializeField]
        public bool ShowAtStartup;

        public string PackageURL => $"https://unity.com";
    }
}
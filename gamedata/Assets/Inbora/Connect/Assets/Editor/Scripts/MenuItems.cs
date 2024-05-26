using UnityEditor;
using UnityEngine;

namespace Ilumisoft.Connect.Editor.GameTemplate
{
    public static class MenuItems
    {
        [MenuItem("Game Template/Connect/Welcome")]
        static void OpenPackageUtility()
        {
            PackageUtilityWindow.Init();
        }

        [MenuItem("Game Template/Connect/Rate")]
        static void Rate()
        {
            var bundleInfo = ScriptableObjectUtility.Find<PackageInfo>();

            if (bundleInfo != null)
            {
                Application.OpenURL(bundleInfo.PackageURL);
            }
        }
    }
}
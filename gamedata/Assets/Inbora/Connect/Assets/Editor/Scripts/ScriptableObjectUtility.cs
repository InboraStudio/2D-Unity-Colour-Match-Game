using UnityEditor;
using UnityEngine;

namespace Ilumisoft.Connect.Editor.GameTemplate
{
    public static class ScriptableObjectUtility
    {
        public static T Find<T>() where T : ScriptableObject
        {
            var loadedInstances = Resources.FindObjectsOfTypeAll<T>();

            if (loadedInstances.Length > 0)
            {
                return loadedInstances[0];
            }
            else
            {
                return LoadAsset<T>();
            }
        }

        static T LoadAsset<T>() where T : ScriptableObject
        {
            var guids = AssetDatabase.FindAssets($"t: {typeof(T)}");

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);

                var asset = AssetDatabase.LoadAssetAtPath<T>(path);

                if (asset != null)
                {
                    return asset;
                }
            }

            return null;
        }
    }
}
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Ilumisoft.Connect.Editor.GameTemplate
{
    public class PackageUtilityWindow : EditorWindow
    {
        PackageInfo packageInfo = null;

        List<PackageData> packageList = new List<PackageData>();

        [InitializeOnLoadMethod]
        static void InitShowAtStartup()
        {
            string sessionKey = "Ilumisoft.PackageUtilityWindow.HasBeenShown";

            // Only show once per session
            if (SessionState.GetBool(sessionKey, false) == true)
            {
                return;
            }
            else
            {
                SessionState.SetBool(sessionKey, true);

                EditorApplication.update += ShowAtStartup;
            }
        }

        static void ShowAtStartup()
        {
            EditorApplication.update -= ShowAtStartup;

            var startupMessageAsset = ScriptableObjectUtility.Find<PackageInfo>();

            if (startupMessageAsset != null && startupMessageAsset.ShowAtStartup && !Application.isPlaying)
            {
                Init();
            }
        }

        public static void Init()
        {
            var window = GetWindow<PackageUtilityWindow>(utility: true);

            window.titleContent = new GUIContent("Welcome");

            window.maxSize = new Vector2(400, 620);
            window.minSize = window.maxSize;
        }

        private void OnEnable()
        {
            packageList.Clear();

            packageInfo = ScriptableObjectUtility.Find<PackageInfo>();

            LoadPackageList();
        }

        private void LoadPackageList()
        {
            packageList.Clear();

            var guids = AssetDatabase.FindAssets($"t: {typeof(PackageData)}");

            for (int i = 0; i < guids.Length; i++)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
                var asset = AssetDatabase.LoadAssetAtPath<PackageData>(assetPath);

                if (asset != null)
                {
                    packageList.Add(asset);
                }
            }
        }

        void OnGUI()
        {
            OnHeaderGUI();

            OnDocumentationGUI();

            OnPackageListGUI();

            OnSupportGUI();

            OnFooterGUI();
        }

        void OnHeaderGUI()
        {
            var headerStyle = new GUIStyle(EditorStyles.label)
            {
                wordWrap = true
            };

            GUILayout.Label(new GUIContent(packageInfo.PackageImage));
            GUILayout.Label($"Thank you (Dr chamyoung) {packageInfo.PackageTitle}!", headerStyle);
        }

        void OnDocumentationGUI()
        {
            GUILayout.Space(18);
            GUILayout.Label("Get Started", EditorStyles.boldLabel);
            GUILayout.Space(8);

            GUILayout.BeginHorizontal();

            GUILayout.Label(new GUIContent("Github"));

            if (GUILayout.Button("Open", GUILayout.Width(100)))
            {
                AssetDatabase.OpenAsset(packageInfo.Documentation);
            }

            GUILayout.EndHorizontal();
        }

        void OnSupportGUI()
        {
            var headerStyle = new GUIStyle(EditorStyles.label)
            {
                wordWrap = true
            };

            GUILayout.Space(18);
            GUILayout.Label("Support", EditorStyles.boldLabel);
            GUILayout.Space(8);
            GUILayout.Label($"If you have any question, feel free to get in touch with us via Discord ID: (Dr.chamyoung)", headerStyle);
        }

        void OnPackageListGUI()
        {
            var headerStyle = new GUIStyle(EditorStyles.miniLabel)
            {
                wordWrap = true
            };

            GUILayout.Space(18);
            GUILayout.Label("Upgrade Options", EditorStyles.boldLabel);
            GUILayout.Space(8);
            GUILayout.Label($"This is a Project From Inbora Studio By Drchamyoung\nIf you find any Problem or want to contac then contact on given account of discord on github:", headerStyle);
            GUILayout.Space(8);

            foreach (var package in packageList)
            {
                GUILayout.BeginHorizontal();

                GUILayout.Label(new GUIContent(package.Name));

                if (GUILayout.Button("Show", GUILayout.Width(100)))
                {
                    Application.OpenURL(package.URL);
                }

                GUILayout.EndHorizontal();
            }
        }

        void OnFooterGUI()
        {
            GUILayout.FlexibleSpace();

            Rect line = GUILayoutUtility.GetRect(position.width, 1);

            EditorGUI.DrawRect(line, Color.black);

            using (new GUILayout.HorizontalScope())
            {
                EditorGUI.BeginChangeCheck();
                bool show = GUILayout.Toggle(packageInfo.ShowAtStartup, " Show on startup");

                if (EditorGUI.EndChangeCheck())
                {
                    packageInfo.ShowAtStartup = show;
                }

                GUILayout.FlexibleSpace();

                if (GUILayout.Button("Close"))
                {
                    Close();
                }
            }
        }
    }
}
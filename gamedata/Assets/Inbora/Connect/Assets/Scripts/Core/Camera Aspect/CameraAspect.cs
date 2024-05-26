namespace Ilumisoft.Connect.Core
{
    using Ilumisoft.Connect.Core.Extensions;
    using UnityEngine;

    /// <summary>
    /// Adjusts the attached Camera to have a specified minimum width
    /// </summary>
    [RequireComponent(typeof(Camera)), ExecuteInEditMode]
    public class CameraAspect : MonoBehaviour
    {
        [SerializeField]
        float minWidth = 6.75f;

        /// <summary>
        /// Reference to the camera
        /// </summary>
        Camera Camera { get; set; }

        Vector2 screenDimensions = Vector2.zero;

        void Start()
        {
            UpdateCameraAspect();
        }

        void ApplyAspectRatio()
        {
            //Reset Camera aspect
            this.Camera = GetComponent<Camera>();
            this.Camera.rect = new Rect(0, 0, 1, 1);
            this.Camera.ResetAspect();

            //Get the current values of the camera
            float cameraWidth = Camera.GetWidth();

            //Is the available width smaller than expected? Apply a letterbox
            if (cameraWidth < minWidth)
            {
                ApplyLetterbox(cameraWidth / minWidth);
            }
        }

        /// <summary>
        /// Sets how many percent of the screen height should be used by the camera
        /// </summary>
        /// <param name="ratio"></param>
        void ApplyLetterbox(float ratio)
        {
            Rect rect = new Rect(0, 0, 1, 1);

            //Apply ratio to the height
            rect.height *= ratio;

            rect.y = (1 - rect.height) / 2;

            //Round values to 4 digits after dot
            rect.y = (float)System.Math.Round(rect.y, 5);
            rect.height = (float)System.Math.Round(rect.height, 5);

            Camera.rect = rect;
        }

        private void Update()
        {
            //Detect and handle screen size changes
            if (screenDimensions.x != Screen.width || screenDimensions.y != Screen.height)
            {
                UpdateCameraAspect();
            }
        }

        void UpdateCameraAspect()
        {
            screenDimensions = new Vector2()
            {
                x = Screen.width,
                y = Screen.height
            };

            ApplyAspectRatio();
        }
    }
}
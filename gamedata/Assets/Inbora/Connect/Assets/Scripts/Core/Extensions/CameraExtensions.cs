namespace Ilumisoft.Connect.Core.Extensions
{
    using UnityEngine;

    /// <summary>
    /// Extension classes for the Camera class
    /// </summary>
    public static class CameraExtensions
    {
        /// <summary>
        /// Returns the height of the camera
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static float GetHeight(this Camera camera)
        {
            return camera.orthographicSize * 2;
        }

        /// <summary>
        /// Returns the width of the camera
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static float GetWidth(this Camera camera)
        {
            return camera.GetHeight() * camera.aspect;
        }
    }
}
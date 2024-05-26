namespace Ilumisoft.Connect.Core.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Vertical gradient used for the background and scene loading UI images
    /// </summary>
    [AddComponentMenu("UI/Effects/Vertical Gradient")]
    public class VerticalGradient : BaseMeshEffect
    {
        public Color topColor = Color.white;
        public Color bottomColor = Color.white;

        /// <summary>
        /// Applies the gradient to the UI element
        /// </summary>
        /// <param name="vertexHelper"></param>
        public override void ModifyMesh(VertexHelper vertexHelper)
        {
            if (this.enabled)
            {
                UIVertex vertex = default;

                float[] t = new float[4] { 0f, 1f, 1f, 0f };

                for (int i = 0; i < vertexHelper.currentVertCount; i++)
                {
                    vertexHelper.PopulateUIVertex(ref vertex, i);

                    vertex.color *= Color.Lerp(this.bottomColor, this.topColor, t[i]);

                    vertexHelper.SetUIVertex(vertex, i);
                }
            }
        }
    }
}
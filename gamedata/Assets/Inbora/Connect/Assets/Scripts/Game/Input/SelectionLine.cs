namespace Ilumisoft.Connect.Game
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Behaviour rendering the connection line between selected elements
    /// </summary>
    [RequireComponent(typeof(LineRenderer))]
    public class SelectionLine : MonoBehaviour
    {
        private LineRenderer lineRenderer = null;
        private Color color;

        /// <summary>
        /// Gets or sets the color of the line
        /// </summary>
        public Color Color
        {
            get { return this.color; }
            set
            {
                this.color = value;
                this.lineRenderer.startColor = value;
                this.lineRenderer.endColor = value;
            }
        }

        private void Awake()
        {
            this.lineRenderer = GetComponent<LineRenderer>();
        }

        /// <summary>
        /// Updates the line for the given list of selected elements
        /// </summary>
        /// <param name="selectedElements"></param>
        public void SetPositions(List<GameGridElement> selectedElements)
        {
            this.lineRenderer.positionCount = selectedElements.Count;

            for (int i = 0; i < selectedElements.Count; i++)
            {
                this.lineRenderer.SetPosition(i, selectedElements[i].transform.position);
            }
        }

        /// <summary>
        /// Clears the line
        /// </summary>
        public void Clear()
        {
            this.lineRenderer.positionCount = 0;
        }
    }
}
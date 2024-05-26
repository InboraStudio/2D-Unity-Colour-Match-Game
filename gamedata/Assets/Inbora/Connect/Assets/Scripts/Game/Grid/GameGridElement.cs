namespace Ilumisoft.Connect.Game
{
    using Ilumisoft.Connect.Core.Extensions;
    using UnityEngine;

    /// <summary>
    /// An elements  in the grid
    /// </summary>
    public class GameGridElement : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer = null;

        /// <summary>
        /// Gets whether the element is moving or not
        /// </summary>
        public bool IsMoving { get; private set; }

        /// <summary>
        /// Returns whether the element is active or not
        /// </summary>
        public bool IsSpawned => this.gameObject.activeSelf;

        /// <summary>
        /// Gets or sets the color of the element
        /// </summary>
        public Color Color
        {
            get { return this.spriteRenderer.color; }
            set { this.spriteRenderer.color = value; }
        }

        /// <summary>
        /// Moves the elements to the given target position (world coordinates)
        /// in the given time
        /// </summary>
        /// <param name="targetPos"></param>
        /// <param name="time"></param>
        public void Move(Vector3 targetPos, float time)
        {
            this.IsMoving = true;

            StartCoroutine(this.transform.MoveCoroutine(targetPos, time, () =>
            {
                this.IsMoving = false;
            }));
        }

        /// <summary>
        /// Activates the element and plays its spawn animation
        /// </summary>
        public void Spawn()
        {
            this.gameObject.SetActive(true);

            Vector2 startScale = Vector2.one * 0.1f;
            Vector2 endScale = Vector2.one * 1.0f;

            StartCoroutine(this.transform.ScaleCoroutine(startScale, endScale, 0.25f));
        }

        /// <summary>
        /// Plays the despawn animation and deactivates the element afterwards
        /// </summary>
        public void Despawn()
        {
            Vector2 startScale = Vector2.one * 1.0f;
            Vector2 endScale = Vector2.one * 0.1f;

            StartCoroutine(this.transform.ScaleCoroutine(startScale, endScale, 0.25f, () =>
            {
                this.gameObject.SetActive(false);
            }));
        }
    }
}
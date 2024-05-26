namespace Ilumisoft.Connect.Core.UI
{
    using UnityEngine;

    /// <summary>
    /// Base class of all user interfaces
    /// </summary>
    public abstract class UserInterface : MonoBehaviour
    {
        /// <summary>
        /// Checks whether the back button( on Android) or the escape key (on windows ) gets pushed and calls 
        /// the OnBackButtonClick() method if so
        /// </summary>
        protected virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnBackButtonClick();
            }
        }

        /// <summary>
        /// Gets called when the back button/esc key is pushed
        /// </summary>
        protected abstract void OnBackButtonClick();
    }
}
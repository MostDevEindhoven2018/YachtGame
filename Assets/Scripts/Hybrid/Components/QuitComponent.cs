using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Hybrid.Components
{
    /// <summary>
    /// Used to close the application
    ///     
    /// Add this component to the button (QuitBtn).
    /// Add the button (QuitBtn) to the field button of the component
    /// </summary>
    public class QuitComponent : MonoBehaviour
    {
        // Clicking this button will close off the application
        public Button button;

        // Boolean to check if the button was clicked
        // At start it will be false
        public bool Clicked = false;

        // Method to change the field Clicked
        void Clicking()
        {
            Clicked = true;
        }

        // At start scene
        void Start()
        {
            // Get the button component of type Button
            button = button.GetComponent<Button>();

            // Listener to a clickevent
            // Waits untill button is clicked to call Clicking method
            button.onClick.AddListener(Clicking);

        }
    }
}




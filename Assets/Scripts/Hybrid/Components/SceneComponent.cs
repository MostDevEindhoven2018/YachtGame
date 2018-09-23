using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Hybrid.Components
{
    /// <summary>
    /// Used to load the scene named LevelName
    ///     
    /// Add this component to the button (HomeBtn, LevelBtn).
    /// Add the button (HomeBtn, LevelBtn) to the field button of the component
    /// Add the name of the scene in the field Level Name
    /// </summary>
    public class SceneComponent : MonoBehaviour
    {
        // Input field for the level name
        public string LevelName;
        // Clicking this button will reload the scene
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




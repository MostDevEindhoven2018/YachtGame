using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Hybrid.Components
{
    /// <summary>
    /// Used to change the menu's in the scene Homepage
    /// For changing to Level Menu, the LevelsBtn can be clicked
    /// For changing back to Main menu, the BackBtn can be clicked
    /// 
    /// Add this component to the button (LevelsBtn and BackBtn).
    /// Add the button (LevelsBtn/BackBtn) to the field button of the component
    /// Add the menus (Level Menu/Main Menu) to the MenuEnable and MenuDisableto of the component
    /// </summary>
    public class MenuChangeComponent : MonoBehaviour
    {
        // Menu that needs to be visable and invisable respectively after button is clicked
        public GameObject MenuEnable, MenuDisable;
        // Clicking this button will change the menu
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




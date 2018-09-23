using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Hybrid.Components
{
    /// <summary>
    /// Used to reload the current scene
    ///     
    /// Add this component to the button (RetryBtn).
    /// Add the button (RetryBtn) to the field button of the component
    /// </summary>
    public class RetrySceneComponent : MonoBehaviour
    {
        // Clicking this button will reload the scene
        public Button Retrybutton;

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
            Retrybutton = Retrybutton.GetComponent<Button>();

            // Listener to a clickevent
            // Waits untill button is clicked to call Clicking method
            Retrybutton.onClick.AddListener(Clicking);

        }
    }
}


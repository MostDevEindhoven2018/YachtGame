using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Hybrid.Components
{
    /// <summary>
    /// Used to freeze the scene and visualize the Level Done Menu when the goal is reached
    ///     
    /// Add this component to the Goal GameObject.
    /// Leave Win Text empty
    /// Add Level Done Menu to the field Menus of the component
    /// Add the NextLevelBtn to the field Next Level Button of the component
    /// Add the RetryBtn to the field Retry Level Button of the component
    /// </summary>
    public class GoalComponent : MonoBehaviour
    {
        // Boolean to check if goal has been reached and the level is completed
        public bool IsCompleted;
        // Text that has to be shown in the Level Done Menu when the goal has been reached or the character has died (not alive)
        public Text WinText;
        // The GameObject Menus has to be shown after the goal has been reached or the character has died
        public GameObject Menus;
        // The GameObject Button that has to hidden when the character died
        public GameObject NextLevelButton;
        // The GameObject Button that has to hidden when the goal has been reached
        public GameObject RetryLevelButton;

        // Method to activate the Level Done Menu and inactive the NextLevel button when the player has to retry level
        public void NextLevelInactive()
        {
            Menus.SetActive(true);
            NextLevelButton.SetActive(false);
        }

        // Method to activate the Level Done Menu and inactive the RetryLevel button when player can go to the next level
        public void RetryLevelInactive()
        {
            Menus.SetActive(true);
            RetryLevelButton.SetActive(false);
        }

        // At start scene
        void Start()
        {
            IsCompleted = false;
            Menus.SetActive(false);
        }

    }
}


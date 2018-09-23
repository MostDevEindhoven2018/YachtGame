
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    /// <summary>
    /// Used to freeze the scene and visualize the Level Done Menu when the goal is reached
    /// </summary>
    public class GoalSystem : ComponentSystem
    {
        // Get game object entities with the GoalComponent
        private struct Goal
        {
            public GoalComponent gc;
        }

        // Get game object entities with the PlayerInput and IsAliveComponent that represent the player's character
        private struct Data
        {
            public ComponentArray<PlayerInput> InputComponents;
            public ComponentArray<IsAliveComponent> IsAlive;
        }

        // Declare dependency on player's character data, injected into OnUpdate
        [Inject] private Data _data;
        protected override void OnUpdate()
        {
            // Get entities with GoalComponents
            var GoalEntity = GetEntities<Goal>();

            // Unfreezes the scene
            Time.timeScale = 1;
                        
            if (GoalEntity.Length > 0)
            {
                // Caluclates horixontal distance between the first goal entity and the first character entity
                var distance =
                    math.distance(GoalEntity[0].gc.transform.position.x, _data.InputComponents[0].transform.position.x);

                if (distance < 0.25)
                {
                    // Sets GoalComponent boolean IsCompleted to true
                    GoalEntity[0].gc.IsCompleted = true;
                }

                // If goal has been reached and the character is still alive
                if ((GoalEntity[0].gc.IsCompleted == true) && (_data.IsAlive[0].isAlive == true))
                {
                    // Set GoalComponent WinText to Level completed
                    GoalEntity[0].gc.WinText.text =
                        SceneManager.GetActiveScene().name.Replace("_", " ") + " completed";

                    // Freezes the scene
                    Time.timeScale = 0;

                    // Checks if the Level Done Menu is inactive in the scene
                    if (GoalEntity[0].gc.Menus.activeInHierarchy == false)
                    {
                        // Calls the RetryLevelInactive method of the GoalComponent to activate Level Done Menu and inactive the RetryBtn
                        GoalEntity[0].gc.RetryLevelInactive();
                    }
                }
                // If the goal has not been reached and the character has died
                else if ((GoalEntity[0].gc.IsCompleted == false) && (_data.IsAlive[0].isAlive == false))
                {
                    // Set GoalComponent WinText Retry Level
                    GoalEntity[0].gc.WinText.text =
                        "Retry " + SceneManager.GetActiveScene().name.Replace("_", " ");

                    // Freezes the scene
                    Time.timeScale = 0;

                    // Checks if the Level Done Menu is inactive in the scene
                    if (GoalEntity[0].gc.Menus.activeInHierarchy == false)
                    {
                        // Calls the NextLevelInactive method of the GoalComponent to activate Level Done Menu and inactive the NextLevelBtn
                        GoalEntity[0].gc.NextLevelInactive();
                    }
                }
                // If the goal has not been reached and the character is still alive
                else
                {
                    // Set GoalComponent WinText to an empty string
                    GoalEntity[0].gc.WinText.text = "";
                }
            }
        }
    }
}


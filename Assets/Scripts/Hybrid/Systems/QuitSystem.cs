using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Entities;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    /// <summary>
    /// Used to close the application
    /// </summary>
    public class QuitSystem : ComponentSystem
    {
        // Get game object entities with the QuitComponent
        private struct Data
        {
            public QuitComponent QuitGame;
        }


        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Data>())
            {
                // For each entity, check if the field Clicked is true
                if (entity.QuitGame.Clicked == true)
                {
                    // Check during Debugging
                    Debug.Log("QUIT");
                    // Closing the application
                    Application.Quit();
                    // Set Clicked field back to false
                    entity.QuitGame.Clicked = false;
                }

            }

        }

    }

}


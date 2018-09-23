using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.SceneManagement;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    /// <summary>
    /// Used to reload the current scene
    /// </summary>
    public class RetrySceneSystem : ComponentSystem
    {
        // Get game object entities with the RetrySceneComponent
        private struct Data
        {
            public RetrySceneComponent retryScene;
        }


        protected override void OnUpdate()
        {
            // For each entity, check if the field Clicked is true
            foreach (var entity in GetEntities<Data>())
            {
                if (entity.retryScene.Clicked == true)
                {
                    // Reloads the current scene
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    // Set Clicked field back to false
                    entity.retryScene.Clicked = false;
                }

            }

        }
    }

}

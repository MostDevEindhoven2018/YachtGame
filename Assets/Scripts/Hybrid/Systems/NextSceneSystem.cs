using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Entities;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    /// <summary>
    /// Used to change to the next scene in the array of scenes
    /// </summary>
    public class NextSceneSystem : ComponentSystem
    {
        // Get game object entities with the NextSceneComponent
        private struct Data
        {
            public NextSceneComponent NextScene;
        }


        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Data>())
            {
                // For each entity, check if the field Clicked is true
                if (entity.NextScene.Clicked == true)
                {
                    // With SceneManager the next scene is loaded
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    // Set Clicked field back to false
                    entity.NextScene.Clicked = false;
                }

            }

        }

    }

}


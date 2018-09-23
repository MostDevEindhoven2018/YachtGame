using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Entities;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    /// <summary>
    /// Used to load the scene named LevelName
    /// </summary>
    public class SceneSystem : ComponentSystem
    {
        // Get game object entities with the SceneComponent
        private struct Data
        {
            public SceneComponent ChangeScene;
        }


        protected override void OnUpdate()
        {
            // For each entity, check if the field Clicked is true
            foreach (var entity in GetEntities<Data>())
            {
                if (entity.ChangeScene.Clicked == true)
                {
                    // Loads scene with LevelName
                    SceneManager.LoadScene(entity.ChangeScene.LevelName);
                    // Set Clicked field back to false
                    entity.ChangeScene.Clicked = false;
                }

            }

        }

    }

}


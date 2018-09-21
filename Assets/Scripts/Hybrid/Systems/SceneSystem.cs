using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Entities;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    public class SceneSystem : ComponentSystem
    {
        private struct Data
        {
            public Components.Scene ChangeScene;
        }


        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Data>())
            {
                if (entity.ChangeScene.Clicked == true)
                {
                    SceneManager.LoadScene(entity.ChangeScene.LevelName);
                    entity.ChangeScene.Clicked = false;
                }

            }

        }

    }

}


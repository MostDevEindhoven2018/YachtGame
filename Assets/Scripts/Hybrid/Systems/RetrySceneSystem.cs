using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.SceneManagement;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    public class RetrySceneSystem : ComponentSystem
    {

        private struct Data
        {
            public RetryScene retryScene;
        }


        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Data>())
            {
                if (entity.retryScene.Clicked == true)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    entity.retryScene.Clicked = false;
                }

            }

        }
    }

}

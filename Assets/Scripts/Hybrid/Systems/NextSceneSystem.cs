﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Entities;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    public class NextSceneSystem : ComponentSystem
    {
        private struct Data
        {
            public NextSceneComponent NextScene;
        }


        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Data>())
            {
                if (entity.NextScene.Clicked == true)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    entity.NextScene.Clicked = false;
                }

            }

        }

    }

}

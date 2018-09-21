using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Entities;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    public class QuitSystem : ComponentSystem
    {
        private struct Data
        {
            public Quit QuitGame;
        }


        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Data>())
            {
                if (entity.QuitGame.Clicked == true)
                {
                    Debug.Log("QUIT");
                    Application.Quit();
                    entity.QuitGame.Clicked = false;
                }

            }

        }

    }

}


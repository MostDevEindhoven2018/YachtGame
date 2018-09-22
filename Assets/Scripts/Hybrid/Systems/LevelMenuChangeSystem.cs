using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Entities;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    public class LevelMenuChangeSystem : ComponentSystem
    {
        private struct Data
        {
            public LevelMenuChangeComponent LevelMenuChange;
        }


        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Data>())
            {
                if (entity.LevelMenuChange.Clicked == true)
                {
                    if (entity.LevelMenuChange.MenuEnable.activeInHierarchy == true)
                    {
                        entity.LevelMenuChange.MenuEnable.SetActive(false);
                        entity.LevelMenuChange.Clicked = false;
                    }
                    else
                    {
                        entity.LevelMenuChange.MenuEnable.SetActive(true);
                        entity.LevelMenuChange.Clicked = false;
                    }
                }

            }

        }

    }
}




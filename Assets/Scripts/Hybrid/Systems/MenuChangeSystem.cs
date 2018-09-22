using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Entities;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    public class MenuChangeSystem : ComponentSystem
    {
        private struct Data
        {
            public MenuChangeComponent MenuChange;
        }


        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Data>())
            {
                if (entity.MenuChange.Clicked == true)
                {
                    entity.MenuChange.MenuEnable.SetActive(true);
                    entity.MenuChange.MenuDisable.SetActive(false);
                    entity.MenuChange.Clicked = false;
                }

            }

        }

    }
}




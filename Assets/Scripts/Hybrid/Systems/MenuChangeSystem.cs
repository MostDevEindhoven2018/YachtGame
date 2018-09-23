using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Entities;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    /// <summary>
    /// Used to change the menu's in the scene Homepage
    /// For changing to Level Menu, the LevelsBtn can be clicked
    /// For changing back to Main menu, the BackBtn can be clicked
    /// </summary>
    public class MenuChangeSystem : ComponentSystem
    {
        // Get game object entities with the MenuChangeComponent
        private struct Data
        {
            public MenuChangeComponent MenuChange;
        }


        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Data>())
            {
                // For each entity, check if the field Clicked is true
                if (entity.MenuChange.Clicked == true)
                {
                    // Enable and Disable one of the menus
                    entity.MenuChange.MenuEnable.SetActive(true);
                    entity.MenuChange.MenuDisable.SetActive(false);
                    // Set Clicked field back to false
                    entity.MenuChange.Clicked = false;
                }

            }

        }

    }
}




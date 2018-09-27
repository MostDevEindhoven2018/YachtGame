using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Entities;
using Assets.Scripts.Hybrid.Components;
using Assets.Scripts.Hybrid.Tags;

namespace Assets.Scripts.Hybrid.Systems
{
    public class MenuSystem : ComponentSystem
    {
        private struct GoalGroup
        {
            public GoalComponent Goal;
        }

        private struct PlayerGroup
        {
            public IsAliveComponent IsAlive;
        }

        private struct InGameMenuGroup
        {
            public InGameMenuContentComponent InGameMenuContent;
        }



        protected override void OnUpdate()
        {
            foreach (var PlayerEntity in GetEntities<PlayerGroup>()) // There is only one entity that is a PlayerEntity, so we are looping through an array of length 1,
                                                                     // but it is nice to keep the same structure going on for all systems, using the foreach loops.
            {
                foreach (var GoalEntity in GetEntities<GoalGroup>()) // Same here.
                {
                    foreach (var InGameMenuEntity in GetEntities<InGameMenuGroup>()) // And here. This might be a bit silly, I agree. 
                    {
                        if(InGameMenuEntity.InGameMenuContent.gameObject.activeInHierarchy == true)
                        {
                            Debug.Log("Menu on");
                        }else if(InGameMenuEntity.InGameMenuContent.gameObject.activeInHierarchy == false)
                                {
                            Debug.Log("Menu off");
                        }
                        

                        if ((GoalEntity.Goal.IsCompleted == true) && (PlayerEntity.IsAlive.isAlive == true))
                        {
                            // The goal is reached and the player is alive. We want to show a victory text and a Next Level Button.
                            SetMenu(InGameMenuEntity, MenuType.Next);

                            Debug.Log("Next Level Should Activate");
                        }
                        else if (PlayerEntity.IsAlive.isAlive == false)
                        {
                            // The player died and has to start over. We want to show a disappointed text and a Retry Level Button.
                            SetMenu(InGameMenuEntity, MenuType.Retry);
                            Debug.Log("Retry Level Should Activate");
                        }
                        else
                        {
                            // Nothing is asking for a Menu or Time freeze, so set the menus to inactive and the timeScale to 1.
                            SetMenu(InGameMenuEntity, MenuType.Disabled);
                            Debug.Log("We 'll regret this");
                        }
                    }
                }
            }
        }

        private void SetMenu(InGameMenuGroup Menu,  MenuType Type)
        {
            switch(Type)
            {
                case MenuType.Next:
                    {
                        Menu.InGameMenuContent.Self.SetActive(true);
                        
                        Menu.InGameMenuContent.Text.text = SceneManager.GetActiveScene().name.Replace("_", " ") + " completed";
                        Menu.InGameMenuContent.NextLevelButton.gameObject.SetActive(true);
                        Menu.InGameMenuContent.RetryLevelButton.gameObject.SetActive(false);
                        break;
                    }
                case MenuType.Retry:
                    {
                        Menu.InGameMenuContent.Self.SetActive(true);
                        Menu.InGameMenuContent.Text.text = "Retry " + SceneManager.GetActiveScene().name.Replace("_", " ");
                        Menu.InGameMenuContent.NextLevelButton.gameObject.SetActive(true);
                        Menu.InGameMenuContent.RetryLevelButton.gameObject.SetActive(false);
                        break;
                    }
                case MenuType.Disabled:
                    {
                        Menu.InGameMenuContent.Self.SetActive(false);
                        break;
                    }
            }
        }

        private enum MenuType
        {
            Next,
            Retry,
            Disabled
        }
    }
}

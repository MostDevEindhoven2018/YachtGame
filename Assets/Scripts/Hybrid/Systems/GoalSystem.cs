
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    public class GoalSystem : ComponentSystem
    {
        private struct GoalGroup
        {
            public GoalComponent Goal;

            public Transform Transform;
        }

        private struct PlayerGroup
        {
            public Transform Transform;
            public PlayerInputComponent PlayerInput;
            public IsAliveComponent IsAlive;
        }


        protected override void OnUpdate()
        {
            foreach (var PlayerEntity in GetEntities<PlayerGroup>()) // There is only one entity that is a PlayerEntity, but it is nice to keep the same structure going on for all systems, using the foreach loops.
            {
                foreach (var GoalEntity in GetEntities<GoalGroup>()) // Same here.
                {
                    Time.timeScale = 1;
                    
                    var distance =
                        math.distance(GoalEntity.Transform.position.x, PlayerEntity.Transform.position.x);

                    if (distance < 0.25)
                    {
                        GoalEntity.Goal.IsCompleted = true;
                    }

                    if ((GoalEntity.Goal.IsCompleted == true) && (PlayerEntity.IsAlive.isAlive == true))
                    {

                        Debug.Log("I am complete and alive");

                        GoalEntity.Goal.WinText.text =
                            SceneManager.GetActiveScene().name.Replace("_", " ") + " completed";

                        Time.timeScale = 0;

                        Debug.Log("After Freeze I am complete and alive");

                        if (GoalEntity.Goal.Menus.activeInHierarchy == false)
                        {
                            GoalEntity.Goal.RetryLevelInactive();
                        }


                    }
                    else if ((GoalEntity.Goal.IsCompleted == false) && (PlayerEntity.IsAlive.isAlive == false))
                    {
                        GoalEntity.Goal.WinText.text =
                            "Retry " + SceneManager.GetActiveScene().name.Replace("_", " ");
                        Time.timeScale = 0;

                        if (GoalEntity.Goal.Menus.activeInHierarchy == false)
                        {
                            GoalEntity.Goal.NextLevelInactive();
                        }
                    }
                    else
                    {
                        //Time.timeScale = 1;
                        GoalEntity.Goal.WinText.text = "";
                    }
                }
            }
        }
    }
}



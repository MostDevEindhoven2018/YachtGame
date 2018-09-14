
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
        private struct Goal
        {
            public GoalComponent gc;
        }

        private struct Data
        {
            public ComponentArray<PlayerInput> InputComponents;
            public ComponentArray<IsAliveComponent> IsAlive;
        }

        [Inject] private Data _data;
        protected override void OnUpdate()
        {
            var GoalEntity = GetEntities<Goal>();

            Time.timeScale = 1;


            if (GoalEntity.Length > 0)
            {
                var distance =
                    math.distance(GoalEntity[0].gc.transform.position.x, _data.InputComponents[0].transform.position.x);

                if (distance < 0.25)
                {
                    GoalEntity[0].gc.IsCompleted = true;
                }

                if ((GoalEntity[0].gc.IsCompleted == true) && (_data.IsAlive[0].isAlive == true))
                {

                    Debug.Log("I am complete and alive");

                    GoalEntity[0].gc.WinText.text =
                        SceneManager.GetActiveScene().name.Replace("_", " ") + " completed";

                    Time.timeScale = 0;

                    Debug.Log("After Freeze I am complete and alive");

                    if (GoalEntity[0].gc.Menus.activeInHierarchy == false)
                    {
                        GoalEntity[0].gc.RetryLevelInactive();
                    }


                }
                else if ((GoalEntity[0].gc.IsCompleted == false) && (_data.IsAlive[0].isAlive == false))
                {
                    GoalEntity[0].gc.WinText.text =
                        "Retry " + SceneManager.GetActiveScene().name.Replace("_", " ");
                    Time.timeScale = 0;

                    if (GoalEntity[0].gc.Menus.activeInHierarchy == false)
                    {
                        GoalEntity[0].gc.NextLevelInactive();
                    }
                }
                else
                {
                    //Time.timeScale = 1;
                    GoalEntity[0].gc.WinText.text = "";
                }
            }
        }
    }
}


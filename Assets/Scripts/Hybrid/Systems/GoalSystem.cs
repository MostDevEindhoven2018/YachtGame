
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
            public Goal Goal;
        }

        private struct PlayerGroup
        {
            public PlayerInput PlayerInput;
            public IsAlive IsAlive;
        }

        [Inject] private PlayerGroup _data;
        protected override void OnUpdate()
        {
            var GoalEntity = GetEntities<GoalGroup>();

            Time.timeScale = 1;


            if (GoalEntity.Length > 0)
            {
                var distance =
                    math.distance(GoalEntity[0].Goal.transform.position.x, _data.InputComponents[0].transform.position.x);

                if (distance < 0.25)
                {
                    GoalEntity[0].Goal.IsCompleted = true;
                }

                if ((GoalEntity[0].Goal.IsCompleted == true) && (_data.IsAlive[0].isAlive == true))
                {

                    Debug.Log("I am complete and alive");

                    GoalEntity[0].Goal.WinText.text =
                        SceneManager.GetActiveScene().name.Replace("_", " ") + " completed";

                    Time.timeScale = 0;

                    Debug.Log("After Freeze I am complete and alive");

                    if (GoalEntity[0].Goal.Menus.activeInHierarchy == false)
                    {
                        GoalEntity[0].Goal.RetryLevelInactive();
                    }


                }
                else if ((GoalEntity[0].Goal.IsCompleted == false) && (_data.IsAlive[0].isAlive == false))
                {
                    GoalEntity[0].Goal.WinText.text =
                        "Retry " + SceneManager.GetActiveScene().name.Replace("_", " ");
                    Time.timeScale = 0;

                    if (GoalEntity[0].Goal.Menus.activeInHierarchy == false)
                    {
                        GoalEntity[0].Goal.NextLevelInactive();
                    }
                }
                else
                {
                    //Time.timeScale = 1;
                    GoalEntity[0].Goal.WinText.text = "";
                }
            }
        }
    }
}


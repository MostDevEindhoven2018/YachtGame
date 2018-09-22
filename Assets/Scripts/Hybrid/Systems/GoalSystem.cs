
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
            public GoalComponent gc;
        }

        private struct PlayerGroup
        {
            public Transform Transform;
            public PlayerInputComponent PlayerInput;
            public IsAliveComponent IsAlive;
        }


        protected override void OnUpdate()
        {
            var GoalEntity = GetEntities<GoalGroup>()[0];
            var PlayerEntity = GetEntities<PlayerGroup>()[0];

            Time.timeScale = 1;



            var distance =
                math.distance(GoalEntity.gc.transform.position.x, PlayerEntity.Transform.position.x);

            if (distance < 0.25)
            {
                GoalEntity.gc.IsCompleted = true;
            }

            if ((GoalEntity.gc.IsCompleted == true) && (PlayerEntity.IsAlive.isAlive == true))
            {

                Debug.Log("I am complete and alive");

                GoalEntity.gc.WinText.text =
                    SceneManager.GetActiveScene().name.Replace("_", " ") + " completed";

                Time.timeScale = 0;

                Debug.Log("After Freeze I am complete and alive");

                if (GoalEntity.gc.Menus.activeInHierarchy == false)
                {
                    GoalEntity.gc.RetryLevelInactive();
                }


            }
            else if ((GoalEntity.gc.IsCompleted == false) && (PlayerEntity.IsAlive.isAlive == false))
            {
                GoalEntity.gc.WinText.text =
                    "Retry " + SceneManager.GetActiveScene().name.Replace("_", " ");
                Time.timeScale = 0;

                if (GoalEntity.gc.Menus.activeInHierarchy == false)
                {
                    GoalEntity.gc.NextLevelInactive();
                }
            }
            else
            {
                //Time.timeScale = 1;
                GoalEntity.gc.WinText.text = "";
            }
        }
    }
}



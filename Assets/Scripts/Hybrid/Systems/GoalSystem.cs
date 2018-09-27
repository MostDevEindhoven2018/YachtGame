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
        }

        private struct PlayerGroup
        {
            public Transform Transform;
            public CollisionComponent Collision;
            public PlayerInputComponent PlayerInput;
            public IsAliveComponent IsAlive;

        }


        protected override void OnUpdate()
        {
            foreach (var PlayerEntity in GetEntities<PlayerGroup>()) // There is only one entity that is a PlayerEntity, but it is nice to keep the same structure going on for all systems, using the foreach loops.
            {
                foreach (var GoalEntity in GetEntities<GoalGroup>()) // Same here.
                {
                    // TimeScale is set to 1. This is normal time. Later this is set to 0 to freeze time.
                    Time.timeScale = 1;

                    // Link the CollisionSystem to this system and continue working with the internal boolean.
                    if (PlayerEntity.Collision.TouchingGoal == true)
                    {
                        GoalEntity.Goal.IsCompleted = true;
                    }
                    else
                    {
                        GoalEntity.Goal.IsCompleted = false;
                    }
                }
            }
        }
    }
}



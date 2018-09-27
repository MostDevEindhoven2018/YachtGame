using Assets.Scripts.Hybrid.Components;
using Assets.Scripts.Hybrid.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Systems
{
    class FreezeSystem :  ComponentSystem
    {

        private struct PlayerGroup
        {
            public PlayerTag Tag;
            public IsAliveComponent IsAlive;
        }

        private struct GoalGroup
        {
            public GoalComponent GoalComponent;
        }


        protected override void OnUpdate()
        {
            foreach (var PlayerEntity in GetEntities<PlayerGroup>())
            {
                foreach (var GoalEntity in GetEntities<GoalGroup>())
                {
                    if (PlayerEntity.IsAlive.isAlive == false || GoalEntity.GoalComponent.IsCompleted == true)
                    {
                        Time.timeScale = 0;
                    }else
                    {
                        Time.timeScale = 1;
                    }
                }
            }
        }
    }
}

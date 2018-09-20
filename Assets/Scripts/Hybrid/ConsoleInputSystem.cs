using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Assets.Scripts.Components;

namespace Assets.Scripts
{
    public class ConsoleInputSystem : ComponentSystem
    {

        public struct ConsoleGroup
        {
            public ConsoleInput ConsoleInput;
        }

        // Update is called once per frame
        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<ConsoleGroup>())
            {
                if (entity.ConsoleInput.Walking == true)
                {
                    entity.ConsoleInput.Horizontal = 1f;
                    //entity.ConsoleInput.Horizontal = Input.GetAxis("Horizontal");
                }
            }
        }
    }
}

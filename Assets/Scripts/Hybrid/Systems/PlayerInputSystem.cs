using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    public class PlayerInputSystem : ComponentSystem
    {
        public struct InputGroup
        {
            public PlayerInputComponent PlayerInput;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<InputGroup>())
            {    
                //checks for A, D, left and right arrow keys. notify movement system.
                entity.PlayerInput.Horizontal = Input.GetAxisRaw("Horizontal");

                //check for the Jump key. notify the Jump System.
                if(Input.GetKeyDown(KeyCode.UpArrow))
                    {
                    entity.PlayerInput.Vertical = 1;
                }
                else
                {
                    entity.PlayerInput.Vertical = 0;
                }
            }
        }
    }
}


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
            public PlayerInput PlayerInput;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<InputGroup>())
            {               
                entity.PlayerInput.Horizontal = Input.GetAxisRaw("Horizontal");
                entity.PlayerInput.Vertical = Input.GetAxisRaw("Vertical");
            }
        }
    }
}


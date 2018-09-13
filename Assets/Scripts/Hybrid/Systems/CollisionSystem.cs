using Assets.Scripts.Hybrid.Components;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Systems
{
    class CollisionSystem : ComponentSystem
    {
        public struct PlayerGroup
        {
            public Transform Transform;
            public PlayerInput PlayerInput;
            public Speed Speed;
            public Rigidbody2D rb;
            public Jump Jump;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<PlayerGroup>())
            {
                entity.Jump.IsGrounded = Physics2D.OverlapBox(new Vector2(entity.Jump.Feet.position.x, entity.Jump.Feet.position.y), new Vector2(entity.Jump.BoxWidth, entity.Jump.BoxHeight), 360.0f, entity.Jump.WhatIsGround);
                
            }
        }
    }
}

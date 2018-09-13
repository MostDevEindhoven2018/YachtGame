﻿using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts
{
    public class JumpSystem : ComponentSystem
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
                
                if (Input.GetKeyDown(KeyCode.UpArrow) && entity.Jump.IsGrounded == true)
                {
                    entity.rb.AddForce(new Vector2(0, entity.Speed.YSpeed));
                }                
            }
        }
    }
}

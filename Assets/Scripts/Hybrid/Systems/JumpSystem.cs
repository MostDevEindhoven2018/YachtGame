using Assets.Scripts.Hybrid.Components;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Systems
{
    public class JumpSystem : ComponentSystem
    {

        public struct PlayerGroup
        {
            public Transform Transform;
            public PlayerInputComponent PlayerInput;
            public SpeedComponent Speed;
            public Rigidbody2D rb;
            public JumpComponent Jump;
        }

        public struct EnvironmentGroup
        {

        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<PlayerGroup>())
            {     
                //If the jump input is received and the characters feet are on the ground. jump the selected height.
                if (entity.PlayerInput.Vertical == 1 && entity.Jump.IsGrounded == true)
                {
                    entity.rb.AddForce(new Vector2(0, entity.Jump.IntendedJumpHeigth));
                }                
            }
        }
    }
}

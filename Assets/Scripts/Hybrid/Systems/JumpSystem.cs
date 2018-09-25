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
            public Rigidbody2D RigidBody;
            public JumpComponent Jump;
            public CollisionComponent Body;
        }

        public struct EnvironmentGroup
        {

        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<PlayerGroup>())
            {     
                
                if (Input.GetKeyDown(KeyCode.UpArrow)  && entity.Body.IsGrounded == true)
                {
                    entity.RigidBody.AddForce(new Vector2(0, entity.Jump.IntendedJumpHeigth));
                }                
            }
        }
    }
}

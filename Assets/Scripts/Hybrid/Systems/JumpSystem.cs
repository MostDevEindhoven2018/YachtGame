using Assets.Scripts.Hybrid.Components;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Systems
{
    public class JumpSystem : ComponentSystem
    {

        public struct PlayerGroup
        {
            public PlayerInputComponent PlayerInput;
            public Rigidbody2D RigidBody;
            public JumpComponent Jump;
            public CollisionComponent Collision;
        }
        
        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<PlayerGroup>())
            {     
                //If the jump input is received and the characters feet are on the ground. jump the selected height.
                if (entity.PlayerInput.Vertical == 1 && entity.Collision.TouchingGround == true)
                {
                    entity.RigidBody.AddForce(new Vector2(0, entity.Jump.IntendedJumpHeigth));
                }                
            }
        }
    }
}

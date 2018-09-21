using Assets.Scripts.Hybrid.Components;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Systems
{
    class CollisionSystem : ComponentSystem
    {
        public struct PlayerGroup
        {
            public Jump Jump;
        }

        // Collision situations.

        // Create functions per situation such as touching the ground or touching enemies.

        private bool CheckGroundedCollision(PlayerGroup entity)
        {
            // Return a boolean whether or not there is overlap between a box created by the first two vectors and ANY gameObject in the given layer.
            return Physics2D.OverlapBox(                                                                                
                    new Vector2(entity.Jump.Feet.position.x, entity.Jump.Feet.position.y),      // Set Position of the box 
                    new Vector2(entity.Jump.BoxWidth, entity.Jump.BoxHeight),                   // Set Measurements of the box
                    360.0f,                                                                                                       // Set Range of Angles to be considered
                    entity.Jump.GroundLayer);                                                                         // Set Layer to be checked against
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<PlayerGroup>())
            {
                // Call all functions
                entity.Jump.IsGrounded =  CheckGroundedCollision(entity);
            }
        }
    }
}

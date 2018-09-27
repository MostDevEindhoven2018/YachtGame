using Assets.Scripts.Hybrid.Components;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Systems
{
    class CollisionSystem : ComponentSystem
    {
        public struct PlayerGroup
        {
            //public PlayerTag PlayerTag;

            public BodyComponent Body;
            public CollisionComponent Collision;
            public Transform Transform;
        }

        // Set Layer to be checked against
        private bool CheckCollision(Vector2 BoxPosition, Vector2 BoxMeasurements, LayerMask Layer)
        {
            // Return a boolean whether or not there is overlap between a box created by the first two vectors and ANY gameObject in the given layer.
            return Physics2D.OverlapBox(
                    BoxPosition,                // Set Position of the box 
                   BoxMeasurements,      // Set Measurements of the box
                    360.0f,                       // Set Range of Angles to be considered
                    Layer);                       // Set Layer to be checked against

            // Set Layer to be checked against
        }

        protected override void OnUpdate()
        {
            foreach (var PlayerEntity in GetEntities<PlayerGroup>())
            {
                // Call all functions
                PlayerEntity.Collision.TouchingGround = CheckCollision(PlayerEntity.Body.FeetPosition, PlayerEntity.Body.FeetMeasurements, PlayerEntity.Collision.GroundCollision);
                PlayerEntity.Collision.TouchingGoal = CheckCollision(PlayerEntity.Body.BodyPosition, PlayerEntity.Body.BodyMeasurements, PlayerEntity.Collision.GoalCollision);
                PlayerEntity.Collision.TouchingEnemy = CheckCollision(PlayerEntity.Body.BodyPosition, PlayerEntity.Body.BodyPosition, PlayerEntity.Collision.EnemyCollision);
            }
        }
    }
}

﻿using Assets.Scripts.Hybrid.Components;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Systems
{
    class CollisionSystem : ComponentSystem
    {
        public struct PlayerGroup
        {
            //public PlayerTag PlayerTag;

            public CollisionComponent Collision;
            public Transform Transform;
        }

        // Collision situations.

        // Create functions per situation such as touching the ground or touching enemies.


        // Set Layer to be checked against
        private bool CheckCollision(Vector2 BoxPosition, Vector2 BoxMeasurements, LayerMask Layer)
        {
            // Return a boolean whether or not there is overlap between a box created by the first two vectors and ANY gameObject in the given layer.
            return Physics2D.OverlapBox(
                    BoxPosition,      // Set Position of the box 
                   BoxMeasurements,                   // Set Measurements of the box
                    360.0f,                                                                                                       // Set Range of Angles to be considered
                    Layer);                                                                         // Set Layer to be checked against

            // Set Layer to be checked against
        }

        protected override void OnUpdate()
        {
            foreach (var PlayerEntity in GetEntities<PlayerGroup>())
            {
                // Call all functions
                PlayerEntity.Collision.IsGrounded = CheckCollision(PlayerEntity.Collision.FeetPosition, PlayerEntity.Collision.FeetMeasurements, PlayerEntity.Collision.GroundCollision);
                //PlayerEntity.Collision.IsGrounded = CheckCollision(PlayerEntity.Collision.BodyPosition, PlayerEntity.Collision.BodyPosition, PlayerEntity.Collision.GoalCollision);
                //PlayerEntity.Collision.IsGrounded = CheckCollision(PlayerEntity.Collision.BodyPosition, PlayerEntity.Collision.BodyPosition, PlayerEntity.Collision.EnemyCollision);
            }
        }
    }
}

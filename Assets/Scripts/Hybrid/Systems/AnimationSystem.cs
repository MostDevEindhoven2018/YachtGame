using Assets.Scripts.Hybrid.Components;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Systems
{
    class AnimationSystem : ComponentSystem
    {
        public struct PlayerGroup
        {
            // Primary Components.

            // Renderer contains the animator and the sprite renderer used to update the sprites.
            public RendererComponent Renderer;
            // It contains: 
             // Animator:  Used to set and update the animations. See the file Cat in the folder Assets\Animations for all transitions and meaning of states.
             // SpriteRenderer: Used to flip the sprite when walking towards the left.

            // Secondary Components.
            public PlayerInputComponent PlayerInput; // Used to check for horizontal movement. This is updated without use of the rigidbody in MovementSystem, so it has no horizontal velocity to work with.
            public CollisionComponent Collision; // Used to check whether or not we are jumping, using the IsGrounded boolean.
        }

        protected override void OnUpdate()
        {
            foreach (var PlayerEntity in GetEntities<PlayerGroup>())
            {
                if (PlayerEntity.Collision.TouchingGround == true) // We are grounded, so set the animation to running or idle
                {
                    if (PlayerEntity.PlayerInput.Horizontal < 0) // We are going to the left, so flip the sprites.
                    {
                        PlayerEntity.Renderer.Animator.SetInteger("State", 2);
                        PlayerEntity.Renderer.SpriteRenderer.flipX = true;
                    }
                    else if (PlayerEntity.PlayerInput.Horizontal > 0) // We are going to the right, so don't flip the sprites.
                    {
                        PlayerEntity.Renderer.Animator.SetInteger("State", 2);
                        PlayerEntity.Renderer.SpriteRenderer.flipX = false;
                    }
                    else // We are stationary, so set state to idle. The flipping of sprites stays as it was. 
                    {
                        PlayerEntity.Renderer.Animator.SetInteger("State", 0);
                    }
                }
                else // We are not grounded, so set the animation to jumping/falling.
                {
                    PlayerEntity.Renderer.Animator.SetInteger("State", 3);
                    if (PlayerEntity.PlayerInput.Horizontal < 0) // We are going to the left, so flip the sprites.
                    {
                        PlayerEntity.Renderer.SpriteRenderer.flipX = true;
                    }
                    else if (PlayerEntity.PlayerInput.Horizontal > 0) // We are going to the right, so don't flip the sprites.
                    {
                        PlayerEntity.Renderer.SpriteRenderer.flipX = false;
                    }
                }
            }
        }
    }
}

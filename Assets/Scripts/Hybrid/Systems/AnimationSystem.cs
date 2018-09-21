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
            public Animator Anim; // Used to set and update the animations. See the file Cat in the folder Assets\Animations for all transitions and meaning of states.
            public SpriteRenderer sr; // Used to flip the sprite when walking towards the left.

            // Secondary Components.
            public PlayerInput PlayerInput; // Used to check for horizontal movement. This is updated without use of the rigidbody in MovementSystem, so it has no horizontal velocity to work with.
            public Jump Jump; // Used to check whether or not we are jumping, using the IsGrounded boolean.
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<PlayerGroup>())
            {

                if (entity.Jump.IsGrounded == true) // We are grounded, so set the animation to running or idle
                {
                    if (entity.PlayerInput.Horizontal < 0) // We are going to the left, so flip the sprites.
                    {
                        entity.Anim.SetInteger("State", 2);
                        entity.sr.flipX = true;
                    }
                    else if (entity.PlayerInput.Horizontal > 0) // We are going to the right, so don't flip the sprites.
                    {
                        entity.Anim.SetInteger("State", 2);
                        entity.sr.flipX = false;
                    }
                    else // We are stationary, so set state to idle. The flipping of sprites stays as it was. 
                    {
                        entity.Anim.SetInteger("State", 0);
                    }
                }
                else // We are not grounded, so set the animation to jumping/falling.
                {
                    entity.Anim.SetInteger("State", 3);
                    if (entity.PlayerInput.Horizontal < 0) // We are going to the left, so flip the sprites.
                    {
                        entity.sr.flipX = true;
                    }
                    else if (entity.PlayerInput.Horizontal > 0) // We are going to the right, so don't flip the sprites.
                    {
                        entity.sr.flipX = false;
                    }
                }
            }
        }
    }
}

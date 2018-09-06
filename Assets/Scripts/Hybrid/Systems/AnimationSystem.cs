using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Hybrid
{
    class AnimationSystem : ComponentSystem
    {
        public struct PlayerGroup
        {
            public PlayerInput PlayerInput;
            public Transform Transform;
            public Speed Speed;
            public Rigidbody2D rb;
            public SpriteRenderer sr;
            public Animator Anim;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<PlayerGroup>())
            {
                if (entity.rb.velocity.y != 0)
                {
                    entity.Anim.SetInteger("State", 3);
                }

                if (entity.PlayerInput.Horizontal < 0)
                {
                    if (entity.rb.velocity.y == 0)
                    {
                        entity.Anim.SetInteger("State", 2);
                    }
                    entity.sr.flipX = true;
                }
                else if (entity.PlayerInput.Horizontal > 0)
                {
                    if (entity.rb.velocity.y == 0)
                    {
                        entity.Anim.SetInteger("State", 2);
                    }
                    entity.sr.flipX = false;
                }
                else
                {
                    if (entity.rb.velocity.y == 0)
                    {
                        entity.Anim.SetInteger("State", 0);
                    }
                }
            }
        }
    }
}

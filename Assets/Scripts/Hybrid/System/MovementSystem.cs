using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Assets.Scripts
{
    public class MovementSystem : ComponentSystem
    {

        public struct MovementGroup
        {
            public Transform Transform;
            public PlayerInput PlayerInput;
            public Speed Speed;
            public Rigidbody2D rb;
            public SpriteRenderer sr;
            public Animator Anim;
        }

        private struct Data
        {
            public ComponentArray<GoalComponent> gc;
        }

        [Inject] private Data _data;
        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<MovementGroup>())
            {
                //declare position variable
                var position = entity.Transform.position;

                //update horizontal movement
                //if (_data.gc[0].IsCompleted)
                //{
                //    entity.Speed.XSpeed = 0;
                //}

                position.x += entity.Speed.XSpeed * entity.PlayerInput.Horizontal * Time.deltaTime;
                
                //
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    entity.rb.AddForce(new Vector2(entity.rb.velocity.x, entity.Speed.YSpeed));
                }

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

                entity.Transform.position = position;
                //entity.Transform.rotation = rotation;
            }
        } 
    }
}

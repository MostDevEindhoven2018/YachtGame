using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts
{
    public class MovementSystem : ComponentSystem
    {

        public struct PlayerGroup
        {
            public Transform Transform;
            public PlayerInput PlayerInput;
            public Speed Speed;
            public Rigidbody2D rb;
            public SpriteRenderer sr;
            public Animator Anim;
        }
        
        protected override void OnUpdate()
        {
            float dt = Time.deltaTime;

            foreach (var entity in GetEntities<PlayerGroup>())
            {
                Vector2 position = entity.Transform.position;

                position.x += entity.Speed.XSpeed * entity.PlayerInput.Horizontal * dt;

                entity.Transform.position = position;
            }
        } 
    }
}

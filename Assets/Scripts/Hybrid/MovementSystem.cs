using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Assets.Scripts.Components;

namespace Assets.Scripts
{
    public class MovementSystem : ComponentSystem
    {

        public struct MovementGroup
        {
            public Transform Transform;
            public ConsoleInput ConsoleInput;
            public Speed Speed;
            public Rigidbody2D rb;
            public SpriteRenderer sr;
            public Animator Anim;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<MovementGroup>())
            {
                //declare position variable
                var position = entity.Transform.position;

                //update horizontal movement
                position.x += entity.Speed.XSpeed * entity.ConsoleInput.Horizontal *10 * Time.deltaTime;

                entity.Transform.position = position;
                //entity.Transform.rotation = rotation;
            }
        }
    }
}
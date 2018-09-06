using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts
{
    public class JumpSystem : ComponentSystem
    {

        public struct PlayerGroup
        {
            public Transform Transform;
            public PlayerInput PlayerInput;
            public Speed Speed;
            public Rigidbody2D rb;
            public Jump Jump;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<PlayerGroup>())
            {
                //if(entity.PlayerInput.JumpReleased)
                //{
                //    entity.Jump.AllowAdditionalHeigth = false;
                //}
                


                if (Input.GetKey(KeyCode.UpArrow) && entity.Jump.AllowAdditionalHeigth)
                {
                    entity.rb.AddForce(new Vector2(0, entity.Speed.YSpeed));
                }

                
            }
        }
    }
}

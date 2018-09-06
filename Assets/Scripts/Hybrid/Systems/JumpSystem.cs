using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts
{
    public class JumpSystem : ComponentSystem
    {

        public struct PlayerGroup
        {
            
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<PlayerGroup>())
            {
               

                
            }
        }
    }
}

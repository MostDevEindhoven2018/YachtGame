using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Systems
{
    public class JumpSystem : ComponentSystem
    {

        public struct PlayerGroup
        {
            
        }

        public struct EnvironmentGroup
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

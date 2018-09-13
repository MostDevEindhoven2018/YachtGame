using Assets.Scripts.Hybrid.Components;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Systems
{

    /// <summary>
    /// Makes the camera follow the player.
    /// </summary>
    class CameraSystem : ComponentSystem
    {
        public struct CameraGroup
        {
            public CameraComponent cameraComponent;
            public Transform Transform;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<CameraGroup>())
            {
                Vector2 position = entity.Transform.position;

                //follows the player in x
                entity.Transform.position = new Vector3(entity.cameraComponent.Player.position.x, entity.cameraComponent.Player.position.y + entity.cameraComponent.YOffset, entity.cameraComponent.transform.position.z);
            }
        }
    }
}

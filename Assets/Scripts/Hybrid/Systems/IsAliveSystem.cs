using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.UI;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    public class IsAliveSystem : ComponentSystem
    {
        private struct Data2
        {
            public EnemyComponent Enemy;
        }

        private struct Data
        {
            public ComponentArray<PlayerInput> PlayerInput;
            public ComponentArray<IsAliveComponent> IsAlive;
        }

        [Inject] private Data _Player;
        protected override void OnUpdate()
        {
            if (_Player.PlayerInput[0].transform.position.y < -3.5)
            {
                _Player.IsAlive[0].Health = 0;
            }

            if (_Player.IsAlive[0].Health <= 0)
            {
                _Player.IsAlive[0].isAlive = false;
            }

            foreach (var entity2 in GetEntities<Data2>())
            {
                var enemyDistance = math.distance(entity2.Enemy.transform.position.y, _Player.PlayerInput[0].transform.position.y);

                if (enemyDistance < 0.5)
                {
                    _Player.IsAlive[0].Health -= entity2.Enemy.Damage;
                }
            }
        }
    }
}




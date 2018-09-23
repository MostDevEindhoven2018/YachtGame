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
    /// <summary>
    /// Used to assess if the player's character is still alive and calculate the health
    /// </summary>
    public class IsAliveSystem : ComponentSystem
    {
        // Get game object entities with the EnemyComponent
        private struct Data2
        {
            public EnemyComponent Enemy;
        }

        // Get game object entities with the PlayerInput and IsAliveComponent that represent the player's character
        private struct Data
        {
            public ComponentArray<PlayerInput> PlayerInput;
            public ComponentArray<IsAliveComponent> IsAlive;
        }

        // Declare dependency on player's character data, injected into OnUpdate
        [Inject] private Data _Player;
        protected override void OnUpdate()
        {
            // Checks if the player's character is still on the platform
            if (_Player.PlayerInput[0].transform.position.y < -3.5)
            {
                // If player's character is below the platform, the health of the character is set to zero, because the character died
                _Player.IsAlive[0].Health = 0;
            }

            // Checks if the character's health is below zero
            if (_Player.IsAlive[0].Health <= 0)
            {
                // Sets boolean IsAlive to false, because the character died
                _Player.IsAlive[0].isAlive = false;
            }

            // Get the Game object entities with EnemyComponent
            foreach (var entity2 in GetEntities<Data2>())
            {               
                // Calculates vertical distance between the enemy and the player's character
                // Was used for water enemies
                var enemyDistance = math.distance(entity2.Enemy.transform.position.y, _Player.PlayerInput[0].transform.position.y);

                // If the vertical distance is below 0.5, the enemy inflicts damage on the character's health
                // Was used for water enemies
                if (enemyDistance < 0.5)
                {
                    // Substracting the damage by the enemy on the character's health
                    _Player.IsAlive[0].Health -= entity2.Enemy.Damage;
                }
            }
        }
    }
}





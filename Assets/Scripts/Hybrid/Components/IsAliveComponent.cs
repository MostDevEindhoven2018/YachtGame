using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Components
{
    /// <summary>
    /// Used to assess if the player's character is still alive and calculate the health
    /// 
    /// Add this component to the Player's character GameObject
    /// </summary>
    public class IsAliveComponent : MonoBehaviour
    {
        // Boolean to check if player's character is still alive
        public bool isAlive;
        // The health status of the character
        protected internal float Health;

        // At start of scene
        void Start()
        {
            // Sets health to 100
            Health = 100;
            // Sets boolean isAlive to true
            isAlive = true;
        }
    }
}



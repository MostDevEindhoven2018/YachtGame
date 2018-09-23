using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Components
{
    /// <summary>
    /// Used to inflict damage on the character's health when the vertical distance between the character and the enemy is small
    ///     
    /// Add this component to the Enemy GameObject.
    /// Give a number to the Damage field of the component
    /// </summary>
    public class EnemyComponent : MonoBehaviour
    {
        // Number given to the damage that the enemy inflicts on the character after the vertical distance  between them is low
        public float Damage;

    }
}
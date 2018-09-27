using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Components
{
    public class CollisionComponent : MonoBehaviour
    {
        // State all the Layer masks that will be used in the system.
        public LayerMask GroundCollision;
        public LayerMask GoalCollision;
        public LayerMask EnemyCollision;

        
        // All booleans that will be used by other systems.
        public bool TouchingGround;
        public bool TouchingGoal;
        public bool TouchingEnemy;
    }
}

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

        // In here, we set all different body parts. For now, we only have feet. Make all body parts private, and create public getters for their measurements and positions for clearer 
        // readability where their are used.

        // Entire Body ( for touching enemies and goalobjects )
        public Transform Body;
        private float BodyBoxWidth;
        private float BodyBoxHeight;

        public Vector2 BodyMeasurements
        {
            get
            {
                return new Vector2(BodyBoxHeight, BodyBoxWidth);
            }
        }

        public Vector2 BodyPosition
        {
            get
            {
                return new Vector2(Body.position.x, Body.position.y);
            }
        }

        // Feet ( for jumping on platforms and enemies)
        public Transform Feet;
        private float FeetBoxWidth;
        private float FeetBoxHeight;

        public Vector2 FeetMeasurements
        {
            get
            {
                return new Vector2(FeetBoxHeight, FeetBoxWidth);
            }
        }

        public Vector2 FeetPosition
        {
            get
            {
                return new Vector2(Feet.position.x, Feet.position.y);
            }
        }

        // All booleans that will be used by other systems.
        public bool IsGrounded;

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(FeetPosition, FeetMeasurements);
            Gizmos.DrawWireCube(BodyPosition, BodyMeasurements);

        }

    }
}

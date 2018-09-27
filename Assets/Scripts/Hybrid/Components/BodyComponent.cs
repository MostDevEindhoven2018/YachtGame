﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Components
{
    class BodyComponent : MonoBehaviour
    {

        // In here, we set all different body parts. For now, we only have feet. Make all body parts private, and create public getters for their measurements and positions for clearer 
        // readability where their are used.

        // Entire Body ( for touching enemies and goal objects )
        public Transform Body;
        public float BodyBoxWidth;
        public float BodyBoxHeight;

        public Vector2 BodyMeasurements
        {
            get
            {
                return new Vector2(BodyBoxWidth, BodyBoxHeight);
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
        public float FeetBoxWidth;
        public float FeetBoxHeight;

        public Vector2 FeetMeasurements
        {
            get
            {
                return new Vector2(FeetBoxWidth, FeetBoxHeight);
            }
        }
        public Vector2 FeetPosition
        {
            get
            {
                return new Vector2(Feet.position.x, Feet.position.y);
            }
        }
   

        // Used in the Scene view to view the measurements and positions of the boxes. ( Click on Gizmos at the upper right corner of the scene view).
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(FeetPosition, FeetMeasurements);
            Gizmos.DrawWireCube(BodyPosition, BodyMeasurements);
        }
    }
}
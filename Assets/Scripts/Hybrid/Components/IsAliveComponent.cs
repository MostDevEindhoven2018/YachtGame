using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Components
{
    public class IsAliveComponent : MonoBehaviour
    {
        public bool isAlive;
        protected internal float Health;

        void Start()
        {
            Health = 100;
            isAlive = true;
        }
    }
}


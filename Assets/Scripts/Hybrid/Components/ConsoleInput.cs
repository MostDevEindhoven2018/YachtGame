using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Entities;
using Unity.Jobs;
using System;
using System.Threading;

namespace Assets.Scripts.Components
{
    public class ConsoleInput : MonoBehaviour
    {
        public float Horizontal;
        public float Vertical;
        public bool Walking = false;

        private List<GameObject> listeners = new List<GameObject>();

        public void Start()
        {
            AddListeners(gameObject);
        }

        private void AddListeners(GameObject listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void Command(string input)
        {
            //name.method(input)
            //Debug.log("Hello")

            string[] parts = input.Split(new char[] { '.', '(', ')' }, 4);

            GameObject go = listeners.SingleOrDefault(obj => obj.name == parts[0]);

            if (go != null)
            {
                go.SendMessage(parts[1], parts[2]);
            }
        }

        public void Walk(int x)
        {
            Walking = true; 
            Debug.Log(x);

            for (int i = 0; i < x; i++)
            {
                Debug.Log(i);
            }
            Walking = false;
        }
    }
}

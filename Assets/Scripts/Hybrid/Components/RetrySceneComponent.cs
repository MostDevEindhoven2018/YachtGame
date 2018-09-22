using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Hybrid.Components
{
    public class RetrySceneComponent : MonoBehaviour
    {

        public Button Retrybutton;

        public bool Clicked = false;

        void Clicking()
        {
            Clicked = true;
        }

        void Start()
        {
            Retrybutton = Retrybutton.GetComponent<Button>();

            Retrybutton.onClick.AddListener(Clicking);

        }
    }
}


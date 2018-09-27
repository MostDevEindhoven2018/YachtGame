using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Hybrid.Components
{
    class InGameMenuContentComponent : MonoBehaviour
    {
        public Text Text;

        public Button NextLevelButton;
        public Button RetryLevelButton;
        public Button ExitButton;

        public GameObject Self; // The component has a reference to the game object itself so the SetActive can be called upon the entire menu and its children.
    }
}

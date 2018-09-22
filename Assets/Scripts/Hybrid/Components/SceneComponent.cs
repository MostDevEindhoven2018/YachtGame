using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Hybrid.Components
{
    public class SceneComponent : MonoBehaviour
    {
        public string LevelName;
        public Button button;

        public bool Clicked = false;

        void Clicking()
        {
            Clicked = true;
        }

        void Start()
        {
            button = button.GetComponent<Button>();

            button.onClick.AddListener(Clicking);

        }
    }
}




using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Hybrid.Components
{
    class ButtonComponent : MonoBehaviour
    {
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

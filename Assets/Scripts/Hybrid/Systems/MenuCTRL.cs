using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Hybrid.Components;

namespace Assets.Scripts.Hybrid.Systems
{
    public class MenuCTRL : MonoBehaviour
    {
        public void LoadScene(string SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}



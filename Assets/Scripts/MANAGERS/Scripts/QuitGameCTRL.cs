using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitGameCTRL : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button = button.GetComponent<Button>();

        button.onClick.AddListener(QuitGame);

        void QuitGame()
        {
            Debug.Log("QUIT");
            Application.Quit();
        }
    }


}
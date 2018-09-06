using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextSceneCTRL : MonoBehaviour
{ 
    public Button button;

    void Start()
    {
        button = button.GetComponent<Button>();

        button.onClick.AddListener(NextLevel);

        void NextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
	

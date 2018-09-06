using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneCTRL : MonoBehaviour
{
    public int LevelNumber;
    public Button button;

    void Start()
    {
        button = button.GetComponent<Button>();

        button.onClick.AddListener(ChangeLevels);

        void ChangeLevels()
        {
            SceneManager.LoadScene(LevelNumber);
        }
    }
}
	

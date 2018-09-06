using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenesCRTL : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //public void HomePage()
    //{
    //    SceneManager.LoadScene(0);
    //}

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void ChangeLevel(int LevelNumber)
    {
        SceneManager.LoadScene(LevelNumber);
    }

    public void ChangeLevelMenu(GameObject Menu)
    {
        if (Menu.activeInHierarchy == true)
        {
            Menu.SetActive(false);
        }
        else
        {
            Menu.SetActive(true);
        }
    }

}


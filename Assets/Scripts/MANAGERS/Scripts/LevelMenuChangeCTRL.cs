using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenuChangeCTRL : MonoBehaviour
{
    public GameObject MenuEnable;
    public Button button;

    void Start()
    {
        button = button.GetComponent<Button>();

        button.onClick.AddListener(ChangeMenus);

        void ChangeMenus()
        {
            if (MenuEnable.activeInHierarchy == true)
            {
                MenuEnable.SetActive(false);
            }
            else
            {
                MenuEnable.SetActive(true);
            }

        }
    }
}
	

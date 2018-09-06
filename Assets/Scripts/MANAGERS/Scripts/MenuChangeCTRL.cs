using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuChangeCTRL : MonoBehaviour
{
    public GameObject MenuEnable, MenuDisable;
    public Button button;

    void Start()
    {
        button = button.GetComponent<Button>();

        button.onClick.AddListener(ChangeMenus);

        void ChangeMenus()
        {
            MenuEnable.SetActive(true);
            MenuDisable.SetActive(false);
        }
    }
}
	

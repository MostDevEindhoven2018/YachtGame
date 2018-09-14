using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuChangeComponent : MonoBehaviour
{
    public GameObject MenuEnable, MenuDisable;
    public Button button;

    public bool Clicked=false;

    void Clicking()
    {
        Clicked=true;
    }

    void Start()
    {
        button = button.GetComponent<Button>();

        button.onClick.AddListener(Clicking);
        
    }
}
	

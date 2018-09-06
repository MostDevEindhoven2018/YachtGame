﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneComponent : MonoBehaviour
{
    public int LevelNumber;
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
	

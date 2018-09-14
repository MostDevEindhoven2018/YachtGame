﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoalComponent : MonoBehaviour {

    public bool IsCompleted;
    public Text WinText;
    public GameObject Menus;
    public GameObject NextLevelButton;
    public GameObject RetryLevelButton;

    public void NextLevelInactive()
    {
        Menus.SetActive(true);
        NextLevelButton.SetActive(false);
    }

    public void RetryLevelInactive()
    {
        Menus.SetActive(true);
        RetryLevelButton.SetActive(false);
    }

    void Start()
    {
        IsCompleted = false;
        Menus.SetActive(false);
    }

}

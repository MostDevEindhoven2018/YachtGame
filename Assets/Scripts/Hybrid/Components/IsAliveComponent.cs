using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAliveComponent : MonoBehaviour {

    public bool isAlive;
    protected internal float Health;

    void Start()
    {
        Health = 100;
        isAlive = true;
    }
}

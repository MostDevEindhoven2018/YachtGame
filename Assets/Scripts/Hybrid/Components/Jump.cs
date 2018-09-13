using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Jump : MonoBehaviour
{
    public float MaxJumpHeigth;
    public float IntendedJumpHeigth;
    public bool IsGrounded;
    public Transform Feet;
    public float BoxWidth;
    public float BoxHeight;
    public LayerMask WhatIsGround;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Feet.position, new Vector3(BoxWidth, BoxHeight,0));
    }
}

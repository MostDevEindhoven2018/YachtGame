﻿using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class PlayerInputSystem : ComponentSystem
{
    public struct InputGroup
    {
        public PlayerInput PlayerInput;
    }

    protected override void OnUpdate()
    {
        foreach (var entity in GetEntities<InputGroup>())
        {
            entity.PlayerInput.Horizontal = Input.GetAxis("Horizontal");
            //entity.PlayerInput.Vertical = Input.GetKeyDown(KeyCode.UpArrow);
        }
    }
}
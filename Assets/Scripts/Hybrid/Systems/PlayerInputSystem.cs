using Unity.Entities;
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
            entity.PlayerInput.Horizontal = Input.GetAxisRaw("Horizontal");

            entity.PlayerInput.JumpPressed = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
            entity.PlayerInput.JumpReleased = Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow);
            //entity.PlayerInput.Vertical = Input.GetKeyDown(KeyCode.UpArrow);
        }
    }
}
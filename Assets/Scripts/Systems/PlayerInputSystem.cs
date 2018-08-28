using UnityEngine;
using Unity.Entities;

public class PlayerInputSystem : ComponentSystem
{
	private struct Data
	{
		public PlayerInputComponent playerInput;
	}


	protected override void OnUpdate()
	{
		foreach (var item in GetEntities<Data>())
		{
			item.playerInput.Horizontal = Input.GetAxis("Horizontal");
			item.playerInput.Vertical= Input.GetAxis("Vertical");

		}

	}
}

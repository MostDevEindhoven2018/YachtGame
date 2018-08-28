using UnityEngine;
using Unity.Entities;

public class PlayerMovementSystem : ComponentSystem
{
	private struct Data
	{
		public Rigidbody rb;
		public PlayerInputComponent playerInput;
	}


	protected override void OnUpdate()
	{
		foreach (var entity in GetEntities<Data>())
		{
			var moveVector = new Vector3(entity.playerInput.Horizontal, entity.playerInput.Vertical);
			var movePosition = entity.rb.position + moveVector.normalized * entity.playerInput.PlayerSpeed * Time.deltaTime;

			entity.rb.MovePosition(movePosition);

		}

	}
}

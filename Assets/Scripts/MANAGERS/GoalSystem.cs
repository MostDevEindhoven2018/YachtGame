using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalSystem : ComponentSystem
{

    private struct Goal
    {
        public GoalComponent gc;
    }

    private struct Data
    {
        public ComponentArray<PlayerInput> InputComponents;
    }

    [Inject] private Data _data;
    protected override void OnUpdate()
    {
        var GoalEntity = GetEntities<Goal>();


        if (GoalEntity.Length > 0)
        {
            var distance = math.distance(GoalEntity[0].gc.transform.position.x, _data.InputComponents[0].transform.position.x);


            //
            if (distance < 0.25)
            {
                GoalEntity[0].gc.IsCompleted = true;
                GoalEntity[0].gc.WinText.text = SceneManager.GetActiveScene().name + " completed";


            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.SceneManagement;

public class RetrySceneSystem : ComponentSystem {

    private struct Data
    {
        public RetrySceneComponent retryScene;
    }


    protected override void OnUpdate()
    {
        foreach (var entity in GetEntities<Data>())
        {
            if (entity.retryScene.Clicked == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                entity.retryScene.Clicked = false;
            }

        }

    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Entities;

public class QuitSystem : ComponentSystem
{
    private struct Data
    {
        public QuitComponent QuitGame;
    }


    protected override void OnUpdate()
    {
        foreach (var entity in GetEntities<Data>())
        {
            if (entity.QuitGame.Clicked==true)
            {                
                Debug.Log("QUIT");
                Application.Quit();
                entity.QuitGame.Clicked = false;
            }
            
        }

    }

}


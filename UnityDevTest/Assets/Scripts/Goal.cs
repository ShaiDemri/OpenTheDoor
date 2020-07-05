using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
      void OnTriggerEnter2D (Collider2D collider)
    {
        
        GameFlow gameFlow = FindObjectOfType<GameFlow>();
        GameObject activeScene = gameFlow.GetActiveScene();
        if(activeScene.name.Contains("Level1")){
            gameFlow.LoadLevel(2);
        }
        if(activeScene.name.Contains("Level2")){
            gameFlow.LoadLevel(1);
        }
         

    }
}

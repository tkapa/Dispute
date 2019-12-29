using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public enum CompletionConditions{
        ecc_None,
        ecc_AllEnemies,
    }

    public CompletionConditions conditions;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            switch(conditions){
                case CompletionConditions.ecc_AllEnemies:
                    if(FindObjectsOfType<EnemyHealth>().Length == 0){
                        FindObjectOfType<PauseManager>().LevelComplete();
                    } else{
                        Debug.Log("Enemies left");
                    }
                break;

                default:
                    FindObjectOfType<PauseManager>().LevelComplete();
                break;
            }
        }
    }
}

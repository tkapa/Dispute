using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    private void Awake() {

      if(instance == null){
        instance = this;
        DontDestroyOnLoad(this);
      } else {
          Destroy(this);
      }      
      Debug.Log(SceneManager.sceneCountInBuildSettings);
    }

    public void LoadNewLevel(){
        int rand = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        SceneManager.LoadScene(rand);
    }
}

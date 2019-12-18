using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class MainMenuManager : MonoBehaviour
{
    public CinemachineVirtualCamera mainCamera = null;

    private void Start() {
        mainCamera.Priority = 11;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            OpenOptionsMenu();
        } else if (Input.GetKeyDown(KeyCode.P)){
            ReturnToMainMenu();
        }
    }

    public void PlayGame(){
        //TODO: Create First level and put the player into it.
        //DESIREABLE: Make a save feature so that people can save? Play should take 10 mins tops
        SceneManager.LoadScene("HDTestingScene");
    }

    public void OpenOptionsMenu(){
        mainCamera.Priority = 9;
    }

    public void ReturnToMainMenu(){
        mainCamera.Priority = 11;
    }

    public void Quit(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

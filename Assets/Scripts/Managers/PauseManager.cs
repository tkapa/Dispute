using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("Menus")]
    public GameObject pauseMenu = null;
    public GameObject optionsMenu = null;
    public GameObject completeMenu = null;

    [Header("Variables")]
    public SOBool isPaused = null;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused.value){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Pause(){
        isPaused.value = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        pauseMenu.SetActive(true);
    }

    public void Resume(){
        isPaused.value = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
    }

    public void OpenOptionsMenu(){
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CloseOptionsMenu(){
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void NextLevel(){
        //TODO: Ability to cross from one level to the next
    }

    public void ReturnToMenu(){
        isPaused.value = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit(){
        isPaused.value = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.None;
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

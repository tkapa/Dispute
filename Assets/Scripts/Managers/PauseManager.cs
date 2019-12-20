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

    public bool levelComplete = false;

    private void Start() {
        if(isPaused.value)
            isPaused.value = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !levelComplete){
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseMenu.SetActive(true);
    }

    public void Resume(){

        if(levelComplete)
            levelComplete = !levelComplete;

        isPaused.value = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        completeMenu.SetActive(false);
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
        Resume();
        SceneManager.LoadScene("HDTestingScene");
    }

    public void LevelComplete(){
        levelComplete = true;
        isPaused.value = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        completeMenu.SetActive(true);
    }

    public void ReturnToMenu(){

        if(levelComplete)
            levelComplete = !levelComplete;

        isPaused.value = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit(){

        if(levelComplete)
            levelComplete = !levelComplete;

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

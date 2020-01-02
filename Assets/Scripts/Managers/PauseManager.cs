using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{
    [Header("Menus")]
    public GameObject pauseMenu = null;
    public GameObject optionsMenu = null;
    public GameObject completeMenu = null;

    [Header("Variables")]
    public SOBool isPaused = null;
    public AudioMixer gameAudioMixer = null;
    public float lowPassFreqMin = 400f;
    public float lowPassFreqMax = 5000f;

    public bool levelComplete = false;

    private void Start() {
        gameAudioMixer.SetFloat("lowPassValue", lowPassFreqMax);

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
        gameAudioMixer.SetFloat("lowPassValue", lowPassFreqMin);
        isPaused.value = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseMenu.SetActive(true);
    }

    public void Resume(){

        if(levelComplete)
            levelComplete = !levelComplete;

        gameAudioMixer.SetFloat("lowPassValue", lowPassFreqMax);
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
        Resume();
        LevelLoader.instance.LoadNewLevel();
    }

    public void LevelComplete(){
        gameAudioMixer.SetFloat("lowPassValue", lowPassFreqMin);
        levelComplete = true;
        isPaused.value = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        completeMenu.SetActive(true);
    }

    public void ReturnToMenu(){
        gameAudioMixer.SetFloat("lowPassValue", lowPassFreqMax);
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

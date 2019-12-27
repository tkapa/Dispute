using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerStress : MonoBehaviour
{
    public SOFloat stress = null;
    public float maximumStress = 100f;

    public ValueBar stressBar = null;
    public AudioMixer gameMixer = null;
    public SOFloat gameSound = null;

    // Start is called before the first frame update
    void Start()
    {
        SetStressValues();
    }

    private void Update() {
        StressIncrease(Time.deltaTime*2f);
    }

    public void StressIncrease(float value){
        stress.value += value;
        SetStressValues();

        if(stress.value >= maximumStress){
            Cursor.lockState = CursorLockMode.None;
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    void SetStressValues(){
        float percent = stress.value/maximumStress;
        stressBar.SetValue(percent);

        gameMixer.SetFloat("disputeVolume", (60*percent)+-50);

        float newMusicValue = (70*(gameSound.value/100)) - ((70*(gameSound.value/100))*percent);
        gameMixer.SetFloat("gameAudioVolume", -70+newMusicValue);
    }
}

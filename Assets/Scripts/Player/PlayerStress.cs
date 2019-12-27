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

    // Start is called before the first frame update
    void Start()
    {
        SetStressValues();
    }

    private void Update() {
        StressIncrease(Time.deltaTime*0.5f);
    }

    public void StressIncrease(float value){
        stress.value += value;
        SetStressValues();
    }

    void SetStressValues(){
        float percent = stress.value/maximumStress;
        stressBar.SetValue(percent);

        gameMixer.SetFloat("disputeVolume", (90*percent)+-70);
        //gameMixer.SetFloat("gameAudioVolume", 20 - (90*percent));
    }
}

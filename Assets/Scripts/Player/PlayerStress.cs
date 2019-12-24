using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStress : MonoBehaviour
{
    public float stress = 0.0f;
    public float maximumStress = 100f;

    public ValueBar stressBar = null;

    // Start is called before the first frame update
    void Start()
    {
        SetStressValues();
    }

    public void StressIncrease(float value){
        stress += value;
        SetStressValues();
    }

    void SetStressValues(){
        stressBar.SetValue(stress/maximumStress);
        //TODO: Increase the sound of the dispute in the background && increase stress when the player isnt playing
    }
}

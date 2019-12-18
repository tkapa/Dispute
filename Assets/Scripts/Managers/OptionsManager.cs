using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [Header("Options")]
    public SOBool invertY = null;
    public SOFloat sensitivity = null;
    public SOFloat fov = null;
    public SOFloat sound = null;

    [Header("UI Elements")]
    public Toggle invertYToggle = null;
    public Slider sensitivitySlider = null;
    public Slider fovSlider = null;
    public Slider soundSlider = null;

    private void Start() {
        invertYToggle.isOn = invertY.value;
        sensitivitySlider.value = sensitivity.value;
        fovSlider.value = fov.value;
        soundSlider.value = sound.value;
    }

    public void ToggleInvertY(bool val){
        invertY.value = val;
    }

    public void ChangeSensitivity(float newSense){
        sensitivity.value = newSense;
    }

    public void ChangeFOV(float newFOV){
        fov.value = newFOV;
        FindObjectOfType<Camera>().fieldOfView = fov.value;
    }

    public void ChangeSound(float newSound){
        sound.value = newSound;
        AudioListener.volume = sound.value;
    }
}

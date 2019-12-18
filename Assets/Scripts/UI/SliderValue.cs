using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValue : MonoBehaviour
{
    public TextMeshProUGUI sliderText = null;
    public Slider slider = null;

    private void Start() {
        sliderText.text = System.Math.Round(slider.value, 2).ToString();
        slider.onValueChanged.AddListener(delegate{UpdateText();});
    }

    void UpdateText(){        
        sliderText.text = System.Math.Round(slider.value, 2).ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    TextMeshProUGUI text = null;

    private void Start() {
      if(TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI t)){
        text = t;
      }
    }

    public void UpdateText(int ammoCount){
      text.text = ammoCount.ToString();
    }
}

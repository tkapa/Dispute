using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueBar : MonoBehaviour
{
    public Transform barTransform = null;

    public void SetValue(float normalisedValue){
        barTransform.localScale = new Vector3(normalisedValue, 1f);
    }
}

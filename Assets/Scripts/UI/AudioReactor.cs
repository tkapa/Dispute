﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioReactor : MonoBehaviour
{
    public Material textMaterial = null;

    // Start is called before the first frame update
    void Start()
    {
        if(TryGetComponent<Renderer>(out Renderer renderer)){
            textMaterial = renderer.material;
        }
		AudioProcessor.instance.onSpectrum.AddListener (OnSpectrum);
    }

    void OnSpectrum (float[] spectrum)
	{
        textMaterial.SetFloat("_GlowInner", spectrum[2]*8);
        textMaterial.SetFloat(ShaderUtilities.ID_GlowOuter, spectrum[5]*8);
	}
}

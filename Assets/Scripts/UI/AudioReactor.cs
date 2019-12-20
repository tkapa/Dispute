using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioReactor : MonoBehaviour
{
    public Material textMaterial = null;

    float bufferTimer = 0;
    float bufferTime = 0.5f;

    bool isGlowing = false;

    // Start is called before the first frame update
    void Start()
    {
        bufferTimer = bufferTime;

        if(TryGetComponent<Material>(out Material mat)){
            textMaterial = mat;
        }

        AudioProcessor processor = FindObjectOfType<AudioProcessor> ();
		//processor.onBeat.AddListener (OnbeatDetected);
		processor.onSpectrum.AddListener (OnSpectrum);
    }

    private void Update() {
        /*if(isGlowing){
            bufferTimer -= Time.deltaTime * Time.deltaTime;
            textMaterial.SetFloat("_GlowInner", bufferTimer);
        } else if(bufferTimer <= 0){
            bufferTimer = bufferTime;
            textMaterial.SetFloat("_GlowInner", 0.0f);
        }*/
    }

    void OnbeatDetected(){
        isGlowing = true;
        textMaterial.SetFloat("_GlowInner", 0.5f);
    }

    void OnSpectrum (float[] spectrum)
	{
		//The spectrum is logarithmically averaged
		//to 12 bands

        textMaterial.SetFloat("_GlowInner", spectrum[2] + 0.1f);
        textMaterial.SetFloat("_GlowOuter", spectrum[5] + 0.1f);

		for (int i = 0; i < spectrum.Length; ++i) {
			Vector3 start = new Vector3 (i, 0, 0);
			Vector3 end = new Vector3 (i, spectrum [i], 0);
			Debug.DrawLine (start, end);
		}
	}
}

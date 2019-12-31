using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveText : MonoBehaviour
{
    TextMeshProUGUI objectiveText = null;

    public int beatCount = 5;
    int beatCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI text)){
            objectiveText = text;
        }

        AudioProcessor processor = FindObjectOfType<AudioProcessor> ();
		processor.onBeat.AddListener(OnBeat);
    }

    void OnBeat(){
        Debug.Log("Beat");
        if(beatCounter >= beatCount){
            gameObject.SetActive(false);
        }
        beatCounter++;
    }
}

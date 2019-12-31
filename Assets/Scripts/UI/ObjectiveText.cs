using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveText : MonoBehaviour
{
    TextMeshProUGUI objectiveText = null;

    public string killEnemiesText = "Kill them all";
    public string reachGoalText = "Reach the goal";

    public int beatCount = 5;
    int beatCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI text)){
            objectiveText = text;
        }

        SetText();

        AudioProcessor processor = FindObjectOfType<AudioProcessor> ();
		processor.onBeat.AddListener(OnBeat);
    }

    void SetText(){
        switch(FindObjectOfType<EndLevel>().conditions){
            case CompletionConditions.ecc_AllEnemies:
                objectiveText.text = killEnemiesText;
            break;

            case CompletionConditions.ecc_None:
                objectiveText.text = reachGoalText;
            break;
        }
    }

    void OnBeat(){
        if(beatCounter >= beatCount){
            gameObject.SetActive(false);
        }
        beatCounter++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour
{
    public static Jukebox instance;

    public AudioClip[] audioClips;

    private AudioSource source = null;

    private void Awake() {

        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }

        if(TryGetComponent<AudioSource>(out AudioSource src)){
            source = src;
        }        
    }

    private void Update() {
        if(!source.isPlaying)
            RandomSong();
    }

    void RandomSong(){
        source.PlayOneShot(audioClips[Random.Range(0,audioClips.Length + 1)]);
    }
}

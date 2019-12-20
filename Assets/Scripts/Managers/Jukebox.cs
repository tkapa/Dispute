using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour
{
    public AudioClip[] audioClips;

    private AudioSource source = null;

    private void Awake() {
        if(TryGetComponent<AudioSource>(out AudioSource src)){
            source = src;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update() {
        if(!source.isPlaying)
            RandomSong();
    }

    void RandomSong(){
        source.PlayOneShot(audioClips[Random.Range(0,audioClips.Length + 1)]);
    }
}

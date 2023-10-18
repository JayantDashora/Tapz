using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{

    // Variables
    [SerializeField] private AudioSource audioSource;
    public static GameAudioManager instance;

    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }    
        else{
            Destroy(gameObject);
            return;
        }
    }

    public void PlaySoundEffect(AudioClip clip, float volume){
        audioSource.PlayOneShot(clip,volume);
    }
}

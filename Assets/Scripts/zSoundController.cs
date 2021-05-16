using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zSoundController : MonoBehaviour {
    public static zSoundController instance;
    public AudioClip SawSoundEffect;
    public AudioClip DeadSoundEffect;
    public AudioClip WindSoundEffect;
    public AudioClip ISE_Key;
    public AudioClip ISE_Door;
    AudioSource audiosource;
	void Start () {
        MakeInstance();
        audiosource = GetComponent<AudioSource>();
        resume();
	}
    void MakeInstance() {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void Pause() {
        AudioListener.volume = 0.0f;
    }
    public void resume() {
        AudioListener.volume = 1.0f;
    }
}

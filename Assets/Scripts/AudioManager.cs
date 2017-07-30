using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip BGM, Battle;
    AudioSource source;

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(gameObject);

        source = GetComponent<AudioSource>();
        PlayBGM();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayBGM()
    {
        if (source.isPlaying)
        {
            source.Stop();

            source.clip = BGM;
            source.Play();
        }
    }

    public void PlayBattle()
    {
        if (source.isPlaying)
        {
            source.Stop();

            source.clip = Battle;
            source.Play();
        }
    }
}

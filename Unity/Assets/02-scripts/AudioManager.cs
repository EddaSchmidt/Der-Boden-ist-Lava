using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour {

    public Sound[] sound;

	void Awake () {
        foreach (Sound s in sound) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
	}

    public void Play(string name) {
        Sound s = Array.Find(sound, sound => sound.name == name);
        s.source.Play();
    }
	
	
}

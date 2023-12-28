using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    [SerializeField] private Sound[] sounds;

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        foreach(Sound s in sounds){
            s.SetSource(gameObject.AddComponent<AudioSource>());
            s.GetSource().clip = s.GetClip();
            s.GetSource().volume = s.GetVol();
        }
    }

    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.GetNome() == name);
        s.GetSource().Play();
    }

    public static SoundManager GetInstance(){
        return instance;
    }

}

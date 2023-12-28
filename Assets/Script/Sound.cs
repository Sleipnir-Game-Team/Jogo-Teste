using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound
{
    [SerializeField] int volume;
    [SerializeField] string nome;
    [SerializeField] AudioClip clip;
    AudioSource source;

    Sound(AudioClip clip, string nome, int volume, AudioSource source){
        this.clip = clip;
        this.nome = nome;
        this.volume = volume;
        this.source = source;
    }

    public string GetNome(){
        return nome;
    }
    public int GetVol(){
        return volume;
    }

    public void SetNome(string nome){
        this.nome = nome;
    }

    public AudioSource GetSource(){
        return source;
    }

    public void SetSource(AudioSource source){
        this.source = source;
    }
    public void SetVol(int volume){
        this.volume = volume;
    }

    public AudioClip GetClip(){
        return clip;
    }
    public void SetClip(AudioClip clip){
        this.clip = clip;
    }
}

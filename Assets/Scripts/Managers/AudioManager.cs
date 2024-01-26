using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private Audio[] sound;
    [SerializeField] private AudioSource[] channel;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }

    public void PlayAudioAtChannel(string clips, int source) {
        channel[source].clip = Array.Find(sound, x => x.name == clips).clip;
        channel[source].Play();
    }

    public void PlayAudioAtIndividualChannel(string clips, AudioSource channel) {
        channel.clip = Array.Find(sound, x => x.name == clips).clip;
        channel.Play();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    private float dTime;
    private bool active;
    private AudioSource src;

    void Awake()
    {
        src = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (active) {
            dTime += Time.deltaTime;
        } 
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground" && dTime < 0.1f) {
            AudioManager.instance.PlayAudioAtIndividualChannel("Metal Pipe", src);
            active = !active;
        }
    }
}

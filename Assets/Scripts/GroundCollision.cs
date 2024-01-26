using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    private float dTime;
    private bool active;
    private AudioSource src;
    private Rigidbody rb;

    void Awake()
    {
        src = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (active) {
            dTime += Time.deltaTime;

            if (dTime > 2.7f) {
                LevelManager.instance.RemoveSound(src.volume * 100);
                active = !active;
            }
        } 
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && dTime < 0.05f) {
            rb.AddForce(transform.right * Random.Range(-5f, 5f));
            rb.AddForce(transform.forward * Random.Range(-5f, 5f));
            rb.AddTorque(transform.right * Random.Range(-5f, 5f));
            rb.AddTorque(transform.forward * Random.Range(-5f, 5f));

            AudioManager.instance.PlayAudioAtIndividualChannel("Metal Pipe", src);
            LevelManager.instance.AddSound(src.volume * 100);
            active = !active;
        } else if (dTime < 0.1f) {
            AudioManager.instance.PlayAudioAtIndividualChannel("Metal Pipe Light", src);
        }
    }
}

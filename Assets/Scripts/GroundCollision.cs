using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    private float dTime;
    private bool active;
    [SerializeField] private bool destroy;
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
            destroy = !destroy;

            if (dTime > 4f) {
                LevelManager.instance.RemoveSound(src.volume * 100);
                active = !active;
            }
        } 

        if (destroy) {
            dTime += Time.deltaTime;

            if (dTime > 10f) {
                Destroy(gameObject);
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
            LevelManager.instance.DecreaseLives(src.volume);
            active = !active;
        } else if (!active) {
            AudioManager.instance.PlayAudioAtIndividualChannel("Metal Pipe Light", src);
        }
    }
}

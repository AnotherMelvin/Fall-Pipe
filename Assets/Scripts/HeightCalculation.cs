using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeightCalculation : MonoBehaviour
{
    private float yPos;
    private AudioSource src;

    void Awake()
    {
        src = GetComponent<AudioSource>();
        yPos = transform.position.y;
    }

    void Update()
    {
        if (transform.position.y > yPos) {
            yPos = transform.position.y;
        }

        src.volume = yPos / 3f;
    }
}

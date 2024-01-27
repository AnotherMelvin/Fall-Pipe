using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeightCalculation : MonoBehaviour
{
    public static HeightCalculation instance;
    private float yPos;
    private AudioSource src;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        }

        src = GetComponent<AudioSource>();
        yPos = transform.position.y;
    }

    void Update()
    {
        if (transform.position.y > yPos) {
            yPos = transform.position.y;
        }

        src.volume = yPos / LevelManager.instance.GetSoundWeight(LevelManager.instance.GetLevel());
    }

    public float GetY() {
        return yPos;
    }
}

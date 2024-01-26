using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("Properties")]
    [SerializeField] private int level;
    [SerializeField] private float[] threshold;

    [Header("Variables")]
    [SerializeField] private float totalSounds;

    [Header("Switch")]
    [SerializeField] private bool pass;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        }

        level = 1;
    }

    void Update()
    {
        if (totalSounds <= 0) {
            totalSounds = 0;
        }

        if (totalSounds >= threshold[level]) {
            pass = !pass;
        }
    }

    public int GetLevel() {
        return level;
    }

    public void AddSound(float x) {
        totalSounds += x;
    }

    public void RemoveSound(float x) {
        totalSounds -= x;
    }
}

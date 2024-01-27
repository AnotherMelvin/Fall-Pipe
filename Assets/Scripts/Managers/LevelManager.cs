using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("Properties")]
    [SerializeField] private int level;
    [SerializeField] private float[] threshold;
    [SerializeField] private float[] soundWeight;
    [SerializeField] private float[] livesWeight;

    [Header("Variables")]
    [SerializeField] private float totalSounds;
    [SerializeField] private float lives;

    [Header("Switch")]
    [SerializeField] private bool pass;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        }

        level = 1;
        lives = 100;
    }

    void Update()
    {
        if (totalSounds <= 0) {
            totalSounds = 0;
        }

        if (lives <= 0) {
            lives = 0;
        }

        if (totalSounds >= threshold[level]) {
            pass = !pass;
        }
    }

    public int GetLevel() {
        return level;
    }

    public float GetSoundWeight(int i) {
        return soundWeight[i - 1];
    }

    public float GetTotalSounds() {
        return totalSounds;
    }

    public void AddSound(float x) {
        totalSounds += x;
    }

    public void RemoveSound(float x) {
        totalSounds -= x;
    }

    public void DecreaseLives(float x) {
        lives -= x * livesWeight[level - 1];
    }
}

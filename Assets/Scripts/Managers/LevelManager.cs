using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("References")]
    [SerializeField] private GameObject door;

    [Header("Properties")]
    [SerializeField] private int level;
    [SerializeField] private float[] threshold;
    [SerializeField] private float[] soundWeight;
    [SerializeField] private float[] livesWeight;

    [Header("Variables")]
    [SerializeField] private float totalSounds;
    [SerializeField] private float lives;
    private float dTime1, dTime2;

    [Header("Switch")]
    [SerializeField] private bool pass;
    [SerializeField] private bool gameOver;

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
            dTime1 += Time.deltaTime;

            if (dTime1 < 0.05f) {
                UIManager.instance.EnableGameOver();
                AudioManager.instance.PlayAudioAtChannel("Yoda", 0);
                gameOver = true;
            }
        }

        if (totalSounds >= threshold[level - 1]) {
            pass = true;
            gameOver = true;
        }

        if (pass) {
            dTime2 += Time.deltaTime;

            if (dTime2 < 0.05f) {
                UIManager.instance.EnableFinish();
            }
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

    public float GetLives() {
        return lives;
    }

    public bool GetPass() {
        return pass;
    }

    public bool GetGameOver() {
        return gameOver;
    }

    public void AddSound(float x) {
        totalSounds += x;
    }

    public void RemoveSound(float x) {
        if (!pass) {
            totalSounds -= x;
        }
    }

    public void DecreaseLives(float x) {
        if (!gameOver) {
            lives -= x * livesWeight[level - 1];
            UIManager.instance.EnableHurt();
        }
    }
}

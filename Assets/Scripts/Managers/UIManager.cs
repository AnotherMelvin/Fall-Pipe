using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("References")]
    [SerializeField] private Image soundMeter;
    [SerializeField] private Image healthMeter;
    [SerializeField] private Image hurtScreen;
    [SerializeField] private Animator hurtAnim;
    [SerializeField] private Image finishScreen;
    [SerializeField] private Animator finishAnim;

    [Header("Properties")]
    [SerializeField] private Color[] healthColor;
    [SerializeField] private float[] soundThreshold;


    void Awake()
    {
        if (instance == null) {
            instance = this;
        }

        hurtScreen.gameObject.SetActive(false);
        finishScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        soundMeter.fillAmount = 1 - (LevelManager.instance.GetTotalSounds() / 500); 
        healthMeter.fillAmount = LevelManager.instance.GetLives() / 100;

        if (healthMeter.fillAmount <= 0.75f && healthMeter.fillAmount > 0.5f) {
            healthMeter.color = healthColor[0];
        } else if (healthMeter.fillAmount <= 0.5f && healthMeter.fillAmount > 0.25f) {
            healthMeter.color = healthColor[1];
        } else if (healthMeter.fillAmount <= 0.25f) {
            healthMeter.color = healthColor[2];
        } else {
            healthMeter.color = healthColor[3];
        }
    }

    public void EnableHurt() {
        if (LevelManager.instance.GetLives() > 0) {
            hurtAnim.SetBool("alive", true);
        }
        hurtScreen.gameObject.SetActive(true);
    }

    public void DisableHurt() {
        hurtAnim.SetBool("alive", false);
        hurtScreen.gameObject.SetActive(false);
    }

    public void EnableFinish() {
        finishScreen.gameObject.SetActive(true);
    }

    public void DisableFinish() {
        finishScreen.gameObject.SetActive(false);
    }
}

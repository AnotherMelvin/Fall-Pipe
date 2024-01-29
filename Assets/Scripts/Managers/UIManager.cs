using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Sound Meter")]
    [SerializeField] private Image soundMeter;

    [Header("Health Meter")]
    [SerializeField] private Image healthMeter;

    [Header("Hurt Screen")]
    [SerializeField] private Image hurtScreen;
    [SerializeField] private Animator hurtAnim;

    [Header("Finish Screen")]
    [SerializeField] private Image finishScreen;
    [SerializeField] private Animator finishAnim;

    [Header("Game Over")]
    [SerializeField] private GameObject gameOver;

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
        gameOver.SetActive(false);
    }

    void Update()
    {
        soundMeter.fillAmount = 1 - (LevelManager.instance.GetTotalSounds() / 300); 
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

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (LevelManager.instance.GetGameOver() && !Input.GetKeyDown(KeyCode.R) && Input.anyKey) {
            SceneManager.LoadScene("menus");
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

    public void EnableGameOver() {
        gameOver.SetActive(true);
    }
}

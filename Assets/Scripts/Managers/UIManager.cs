using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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

    [Header("Cooldown Indicator")]
    [SerializeField] private Image barCoolImage;

    [Header("Game Over")]
    [SerializeField] private GameObject gameOver;

    [Header("Instructions")]
    [SerializeField] private GameObject inst;

    [Header("Door")]
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject trigger;

    [Header("Time")]
    [SerializeField] private TMP_Text timeText;

    [Header("Properties")]
    [SerializeField] private Color[] healthColor;
    [SerializeField] private float[] soundThreshold;
    private bool coolInd;
    private bool startTimer;
    private float dTime;
    private float coolDTime;
    private float seconds;
    private float minutes;


    void Awake()
    {
        if (instance == null) {
            instance = this;
        }

        barCoolImage.fillAmount = 0;
        hurtScreen.gameObject.SetActive(false);
        finishScreen.gameObject.SetActive(false);
        gameOver.SetActive(false);
        door.SetActive(false);
    }

    void Update()
    {
        soundMeter.fillAmount = 1 - (LevelManager.instance.GetTotalSounds() / 300); 
        healthMeter.fillAmount = LevelManager.instance.GetLives() / 100;
        timeText.text = Mathf.FloorToInt(minutes).ToString("00") + ":" + Mathf.FloorToInt(seconds).ToString("00");

        if (startTimer && !LevelManager.instance.GetGameOver()) {
            seconds += Time.deltaTime;

            if (Input.anyKeyDown) {
                inst.SetActive(false);
            }
        }

        if (seconds >= 60f) {
            seconds = 0;
            minutes++;
        }

        if (coolInd) {
            if (coolDTime >= 0 && coolDTime < 1.5f) {
                coolDTime += Time.deltaTime;
                barCoolImage.fillAmount = 1f - (coolDTime/1.5f);
            } else {
                coolDTime = 0;
                coolInd = false;
            }
        }

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

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("menus");
        }

        if (LevelManager.instance.GetGameOver()) {
            dTime += Time.deltaTime;

            if (dTime > 3f && !Input.GetKeyDown(KeyCode.R) && Input.anyKey) {
                SceneManager.LoadScene("menus");
            }
        }
    }

    public void SetStartTimer() {
        startTimer = true;
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

    public void EnableDoor() {
        door.SetActive(true);
        trigger.SetActive(false);
    }

    public void EnableCoolIndicator() {
        if (!coolInd) {
            coolInd = true;
        } 
    }
}

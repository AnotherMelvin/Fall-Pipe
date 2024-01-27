using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image soundMeter;

    void Update()
    {
        soundMeter.fillAmount = 1 - (LevelManager.instance.GetTotalSounds() / 500); 
    }
}

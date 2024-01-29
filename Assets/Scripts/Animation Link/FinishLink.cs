using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLink : MonoBehaviour
{
    public void PlayAudio() {
        AudioManager.instance.PlayAudioAtChannel("Taco Bell", 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeScript : MonoBehaviour
{
    float timer = 10;

    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if (timer <= 0) Destroy(this.gameObject);
    }
}

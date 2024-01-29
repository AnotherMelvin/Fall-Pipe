using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camHolder : MonoBehaviour
{
    public Transform camera;
    public Transform player;
    void Update()
    {
        camera.transform.position = this.transform.position;
        this.transform.position = player.transform.position;
    }
}

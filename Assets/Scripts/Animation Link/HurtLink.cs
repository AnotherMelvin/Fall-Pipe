using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtLink : MonoBehaviour
{
    public void DisableLink() {
        UIManager.instance.DisableHurt();
    }
}

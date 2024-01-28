using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLink : MonoBehaviour
{
    public void DisableLink() {
        UIManager.instance.DisableFinish();
    }
}

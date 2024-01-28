using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwScript : MonoBehaviour
{
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    public int totalThrows;
    public float throwCooldown;

    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;
    void Start()
    {
        readyToThrow = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }
    }
    private void Throw()
    {
        readyToThrow = false;
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;
        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
        totalThrows--;
        ResetThrow();
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}

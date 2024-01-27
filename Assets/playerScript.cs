using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float speed;
    float h, v;
    public Transform ori;
    Vector3 moveDir;
    Rigidbody rb;

    public float groundDrag;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        moveDir = ori.forward * v + ori.right * h;
        rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }
}

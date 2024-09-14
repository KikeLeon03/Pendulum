using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XZAxisMovement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    
    private new Transform transform;

    public float limitPos = 30;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        // Keyboard movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalMovement * speed, 0, verticalMovement * speed);

        // Stage limits
        if ((transform.position.x < -limitPos && rb.velocity.x < 0) || (transform.position.x > limitPos && rb.velocity.x > 0)){
            // Stop outgoing velocity
            rb.velocity = new Vector3(0,0,rb.velocity.z);
            
            // Correct Position
            float correctionPosX = transform.position.x > 0 ? limitPos + 0.5f: -limitPos - 0.5f;
            transform.position = new Vector3(correctionPosX, transform.position.y, transform.position.z);
        }
        // Stage limits
        if ((transform.position.z < -limitPos && rb.velocity.z < 0) || (transform.position.z > limitPos && rb.velocity.z > 0)){
            // Stop outgoing velocity
            rb.velocity = new Vector3(rb.velocity.x,0,0);
            
            // Correct Position
            float correctionPosZ = transform.position.z > 0 ? limitPos + 0.5f: -limitPos - 0.5f;
            transform.position = new Vector3(transform.position.x, transform.position.y, correctionPosZ);
        }

        // Mouse movement
        /*
        float mouseMovement = Input.GetAxis("Mouse X");
        transform.position += new Vector3(mouseMovement * speed * Time.deltaTime, 0, 0);
        */
    }
}


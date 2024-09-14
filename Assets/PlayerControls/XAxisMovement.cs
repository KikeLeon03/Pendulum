using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XAxisMovement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    
    private new Transform transform;

    private Vector3 agentVelocityOrder;

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
        
        // Add player and agent velocity orders
        rb.velocity = new Vector3(horizontalMovement * speed, 0, 0);
        rb.velocity += agentVelocityOrder;

        // Stage limits
        if ((transform.position.x < -limitPos && rb.velocity.x < 0) || (transform.position.x > limitPos && rb.velocity.x > 0)){
            // Stop outgoing velocity
            rb.velocity = new Vector3(0,0,0);
            
            // Correct Position
            float correctionPos = transform.position.x > 0 ? limitPos + 0.5f: -limitPos - 0.5f;
            transform.position = new Vector3(correctionPos, transform.position.y, transform.position.z);
        }

        // Mouse movement
        /*
        float mouseMovement = Input.GetAxis("Mouse X");
        transform.position += new Vector3(mouseMovement * speed * Time.deltaTime, 0, 0);
        */
    }
    public void AgentVelocityOrder(int order)
    {
        agentVelocityOrder = new Vector3(speed * order,0,0);
    }
}

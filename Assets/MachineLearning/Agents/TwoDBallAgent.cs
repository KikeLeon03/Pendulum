using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.VisualScripting;
using UnityEngine;

public class TwoDBallAgent : Agent
{
    [SerializeField] public Transform ballTransform;
    [SerializeField] public XAxisMovement XAxisMovement;
    [SerializeField] public Transform cylinderTransform;
    [SerializeField] public Rigidbody ballRB;
    public override void CollectObservations(VectorSensor sensor)
    {
        // Hinge (player) position
        sensor.AddObservation(transform.position.x);

        // Cylinder rotation angle
        sensor.AddObservation(cylinderTransform.localRotation.z);

        // Ball speed
        sensor.AddObservation(ballRB.velocity.x);
        sensor.AddObservation(ballRB.velocity.y);

        // Ball size
        sensor.AddObservation(ballTransform.localScale.x);

        
    }
    public override void OnActionReceived(ActionBuffers actions) {
        XAxisMovement.AgentVelocityOrder(actions.DiscreteActions[0] - 1);
    }

    // Heuristic lets you override Agent desitions
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        float xRawInput = Input.GetAxisRaw("Horizontal");

        // Set Input to an integer
        if(xRawInput < 0) { xRawInput = -1; }
        else { if(xRawInput > 0) { xRawInput = 1; } }

        int xInput = (int) xRawInput;
        
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
        discreteActions[0] = xInput;
    }
}
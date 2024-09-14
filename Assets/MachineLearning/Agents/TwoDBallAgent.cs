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

    public override void CollectObservations(VectorSensor sensor)
    {
        // Hinge position
        sensor.AddObservation(transform.position.x);

        // Ball position and size
        sensor.AddObservation(ballTransform.position.x);
        sensor.AddObservation(ballTransform.position.y);
        sensor.AddObservation(ballTransform.localScale.x);
    }
    public override void OnActionReceived(ActionBuffers actions) {
        XAxisMovement.AgentVelocityOrder(actions.DiscreteActions[0] - 1);
    }
}
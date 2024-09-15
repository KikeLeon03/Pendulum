using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class SantaClaus : MonoBehaviour
{
    [SerializeField] public Transform ballTrasform;
    [SerializeField] public Agent agent;
    private int frameCounter;
    public int rewardFrameStep = 6;
    public float expReward = 2;
    public float boundReward = -30;

    private void Start()
    {
        frameCounter = 0;
    }
    void Update()
    {
        if(frameCounter == rewardFrameStep)
        {
            giveAgentBallReward();
            frameCounter = 0;
        }
        frameCounter++;
    }
    public void giveAgentBallReward()
    {
        if(ballTrasform.localPosition.y < 0) { agent.AddReward(ballTrasform.localPosition.y); }
        else { agent.AddReward(Mathf.Pow(ballTrasform.localPosition.y - boundReward, expReward)); }
    }
}

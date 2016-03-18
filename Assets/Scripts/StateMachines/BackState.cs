using UnityEngine;
using System.Collections;

public class BackState : IFootPadState
{
    private readonly StatePatternFootPad footPad;
    private bool moved;
    public BackState(StatePatternFootPad statePatternFootpad)
    {
        moved = false;
        footPad = statePatternFootpad;
    }
    public void UpdateState()
    {
        if (moved == false)
        {
            moveBack();
            moved = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        moveFront();
        if (footPad.rightLegNext == false)
        {
            ToRightState();
        }
        else
        {
            ToLeftState();
        }
        footPad.toggleLeg();
    }
    public void ToRightState()
    {
        footPad.currentState = footPad.rightState;
    }
    public void ToLeftState()
    {
        footPad.currentState = footPad.leftState;
    }
    public void ToFrontState()
    {
        Debug.Log("Not a valid move");
    }
    public void ToBackState()
    {
        Debug.Log("Not a valid move");
    }
    void moveFront()
    {
        footPad.transform.position = footPad.transform.position + new Vector3(0.0f, 0.0f, footPad.stepFront);
    }
    void moveBack()
    {
        footPad.transform.position = footPad.transform.position + new Vector3(0.0f, 0.0f, footPad.stepBack);
    }
}

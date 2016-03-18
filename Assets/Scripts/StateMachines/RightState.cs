using UnityEngine;
using System.Collections;

public class RightState : IFootPadState
{
    private readonly StatePatternFootPad footPad;
    private bool moved;
    public RightState (StatePatternFootPad statePatternFootpad)
    {
        moved = false;
        footPad = statePatternFootpad;
    }
    public void UpdateState()
    {
        if(moved == false)
        {
            moveRight();
            moved = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        moveLeft();
        if (footPad.rightLegNext == true)
        {
            ToFrontState();
        }
        else
        {
            ToBackState();
        }
        footPad.toggleLeg();
    }
    public void ToRightState()
    {
        Debug.Log("Not a valid move");
    }
    public void ToLeftState()
    {
        Debug.Log("Not a valid move");
    }
    public void ToFrontState()
    {
        footPad.currentState = footPad.frontState;
    }
    public void ToBackState()
    {
        footPad.currentState = footPad.backState;
    }

    void moveRight ()
    {
        footPad.transform.position = footPad.transform.position + new Vector3(footPad.stepRight, 0.0f, 0.0f);

    }
    void moveLeft()
    {
        footPad.transform.position = footPad.transform.position + new Vector3(footPad.stepLeft, 0.0f, 0.0f);

    }
}

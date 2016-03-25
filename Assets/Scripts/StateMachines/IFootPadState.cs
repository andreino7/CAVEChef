using UnityEngine;
using System.Collections;

public interface IFootPadState
{
    void UpdateState();
    void OnTriggerEnter(Collider other);
    void ToRightState();
    void ToLeftState();
    void ToFrontState();
    void ToBackState();
}

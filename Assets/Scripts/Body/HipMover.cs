using UnityEngine;
using System.Collections;

public class HipMover : MonoBehaviour {

	public GameObject rightLeg;
	private Quaternion targetRotation;
	private Vector3 hipToRightLeg;
	private Quaternion hipRotationOffset;
	private bool trigger;

	// Use this for initialization
	void Start () {
		hipToRightLeg = transform.position - rightLeg.transform.position;
		targetRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = rightLeg.transform.position + hipToRightLeg;
		transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,(getReal3D.Input.GetSensor("LegRx").rotation * hipRotationOffset).eulerAngles.y,270));
		if(trigger) {
			trigger = false;
			hipRotationOffset = Quaternion.Inverse(getReal3D.Input.GetSensor("LegRx").rotation) * targetRotation;
		}
	}

	public void SetTrigger() {
		trigger = true;
	}
}

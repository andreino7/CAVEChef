using UnityEngine;
using System.Collections;

public class LegMover : MonoBehaviour {

	public GameObject rightKnee;
	public GameObject rightFoot;
	public GameObject leftKnee;
	public GameObject leftFoot;
	public GameObject leftUpLeg;
	public GameObject hips;
	public GameObject rightUpLeg;
	public Quaternion rightKneeRotationOffset;
	public Quaternion rightLegRotationOffset;
	public Quaternion rightFootRotationOffset;
	public Quaternion hipRotationOffset;
	public Vector3 rightKneeTranslationOffset;
	public Vector3 rightLegTranslationOffset;
	public Vector3 rightFootTranslationOffset;

	public Quaternion leftKneeRotationOffset;
	public Quaternion leftLegRotationOffset;
	public Quaternion leftFootRotationOffset;
	public Vector3 leftKneeTranslationOffset;
	public Vector3 leftLegTranslationOffset;
	public Vector3 leftFootTranslationOffset;

	public bool trigger;

	Quaternion rightKneeRotationTarget;
	Quaternion rightLegRotationTarget;
	Quaternion rightFootRotationTarget;

	Quaternion hipRotationTarget;

	Quaternion leftKneeRotationTarget;
	Quaternion leftLegRotationTarget;
	Quaternion leftFootRotationTarget;

	Vector3 hipToRightLeg;
	Vector3 hipToLeftLeg;
	float rightTightLength;
	float leftTightLength;
	float hipsLength;

	// Use this for initialization
	void Start () {
	//	RightKneeOffset = new Vector3(0f,0f,0f);
	//	RightLegOffset = new Vector3(0f,0f,0f);
		rightLegRotationTarget = rightUpLeg.transform.localRotation;
		rightKneeRotationTarget = rightKnee.transform.rotation;
		rightFootRotationTarget = rightFoot.transform.rotation;

		hipRotationTarget = hips.transform.rotation;

		leftLegRotationTarget = leftUpLeg.transform.localRotation;
		leftKneeRotationTarget = leftKnee.transform.rotation;
		leftFootRotationTarget = leftFoot.transform.rotation;

		hipToRightLeg = hips.transform.position - rightUpLeg.transform.position;
		hipToLeftLeg = hips.transform.position - leftUpLeg.transform.position;

		rightTightLength = (rightKnee.transform.position - rightUpLeg.transform.position).magnitude;
		leftTightLength = (leftKnee.transform.position - leftUpLeg.transform.position).magnitude;
		hipsLength = (rightUpLeg.transform.position - leftUpLeg.transform.position).magnitude;

	}
	
	// Update is called once per frame
	void Update () {
		rightKnee.transform.position = getReal3D.Input.GetSensor("KneeRx").position;
		rightKnee.transform.rotation = getReal3D.Input.GetSensor("KneeRx").rotation * rightKneeRotationOffset;
		rightFoot.transform.position = getReal3D.Input.GetSensor("FootRx").position;
		rightFoot.transform.rotation = getReal3D.Input.GetSensor("FootRx").rotation * rightFootRotationOffset;
		rightUpLeg.transform.position = getReal3D.Input.GetSensor("UpperLegRx").position;
		rightUpLeg.transform.rotation = getReal3D.Input.GetSensor("UpperLegRx").rotation * rightLegRotationOffset;



		leftKnee.transform.position = getReal3D.Input.GetSensor("KneeLx").position;
		leftKnee.transform.rotation = getReal3D.Input.GetSensor("KneeLx").rotation * leftKneeRotationOffset;
		leftFoot.transform.position = getReal3D.Input.GetSensor("FootLx").position;
		leftFoot.transform.rotation = getReal3D.Input.GetSensor("FootLx").rotation * leftFootRotationOffset;
		leftUpLeg.transform.position = getReal3D.Input.GetSensor("UpperLegLx").position;
		leftUpLeg.transform.rotation = getReal3D.Input.GetSensor("UpperLegLx").rotation * leftLegRotationOffset;
		hips.transform.position = rightUpLeg.transform.position + hipToRightLeg;
		hips.transform.rotation = Quaternion.Euler(new Vector3(hips.transform.rotation.x,(getReal3D.Input.GetSensor("UpperLegRx").rotation * hipRotationOffset).eulerAngles.y,270));


		//knee.transform.LookAt(foot.transform);

//		Debug.DrawRay(knee.transform.position, getReal3D.Input.GetSensor("KneeRx").rotation * Vector3.forward, Color.green);
//		Debug.DrawRay(foot.transform.position, getReal3D.Input.GetSensor("FootRx").rotation * Vector3.forward, Color.red);
		if(trigger) {
			rightKneeRotationOffset = Quaternion.Inverse(getReal3D.Input.GetSensor("KneeRx").rotation) * rightKneeRotationTarget;
			rightFootRotationOffset = Quaternion.Inverse(getReal3D.Input.GetSensor("FootRx").rotation) * rightFootRotationTarget;
			rightLegRotationOffset = Quaternion.Inverse(getReal3D.Input.GetSensor("UpperLegRx").rotation) * rightLegRotationTarget;
			hipRotationOffset = Quaternion.Inverse(getReal3D.Input.GetSensor("UpperLegRx").rotation) * hipRotationTarget;

			leftKneeRotationOffset = Quaternion.Inverse(getReal3D.Input.GetSensor("KneeLx").rotation) * leftKneeRotationTarget;
			leftFootRotationOffset = Quaternion.Inverse(getReal3D.Input.GetSensor("FootLx").rotation) * leftFootRotationTarget;
			leftLegRotationOffset = Quaternion.Inverse(getReal3D.Input.GetSensor("UpperLegLx").rotation) * leftLegRotationTarget;

			//knee.transform.localScale *= (knee.transform.position - rightUpLeg.transform.position).magnitude / rightTightLength;
			rightKnee.transform.localScale = new Vector3(1f,(rightKnee.transform.position - rightUpLeg.transform.position).magnitude / rightTightLength, 1f);
			leftKnee.transform.localScale = new Vector3(1f,(leftKnee.transform.position - leftUpLeg.transform.position).magnitude / leftTightLength, 1f);
			transform.localScale = new Vector3((rightUpLeg.transform.position - leftUpLeg.transform.position).magnitude / hipsLength,1f,1f);

			trigger = false;
		}
	}

	public void SetTrigger() {
		trigger = true;
	}
}

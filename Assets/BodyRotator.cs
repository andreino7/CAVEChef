using UnityEngine;
using System.Collections;

public class BodyRotator : MonoBehaviour {
	public GameObject leftLeg;
	public GameObject rightLeg;
	public GameObject hip;
	// Use this for initialization

	void Start () {
		transform.position = rightLeg.transform.position;
		transform.rotation = rightLeg.transform.rotation;
		//Transform t = new Transform(transform);
		Vector3 position = new Vector3(leftLeg.transform.position.x, rightLeg.transform.position.y, leftLeg.transform.position.z);
		transform.LookAt(position);
		hip.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = new Vector3(leftLeg.transform.position.x, rightLeg.transform.position.y, leftLeg.transform.position.z);
		transform.LookAt(position);
	}
}

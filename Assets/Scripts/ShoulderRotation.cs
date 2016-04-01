using UnityEngine;
using System.Collections;

public class ShoulderRotation : MonoBehaviour {
	public Transform targetElbow;
	private Vector3 targetOffset;
	public GameObject parent;
	private float distance;
	// Use this for initialization
	void Start () {
		//Quaternion initialRotation =  Quaternion.Euler(transform.rotation.eulerAngles);
		//transform.LookAt(targetElbow.transform);
		//targetOffset = Quaternion.FromToRotation(transform.rotation * Vector3.one, initialRotation * Vector3.one);
		//transform.rotation = initialRotation;
		parent.transform.LookAt(targetElbow);
		transform.parent = parent.transform;
		distance = (targetElbow.position - transform.position).magnitude;
		//targetOffset = (targetElbow.position - transform.position) - transform.forward;

	}
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt(targetElbow);
		//transform.rotation *= targetOffset;
		//transform.rotation *= Quaternion.FromToRotation(transform.forward, (targetElbow.position - transform.position) - targetOffset);
		parent.transform.LookAt(targetElbow);
		parent.transform.localScale = new Vector3((targetElbow.position - transform.position).magnitude / distance, 1f, 1f);


	}
}

using UnityEngine;
using System.Collections;

public class VelocityCalculator : MonoBehaviour {

	public float speed = 0f;
	public float speedTimeCalc = 1f;

	private Vector3 lastPos;
	// Use this for initialization
	void Start () {
		lastPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		speed = (Vector3.Distance (transform.position, lastPos)) / Time.fixedDeltaTime;
		lastPos = transform.position;
	}
}

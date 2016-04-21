using UnityEngine;
using System.Collections;

public class Kickable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("FootPadPresser")) {
			float sp = other.gameObject.GetComponent<VelocityCalculator> ().speed;
			Debug.Log (sp);
		}
	}
}

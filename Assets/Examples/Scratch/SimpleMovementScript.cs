using UnityEngine;
using System.Collections;

public class SimpleMovementScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float forward = Input.GetAxis("Vertical") * 5;
		float strafe = Input.GetAxis("Horizontal") * 5;

		transform.Translate( forward * Vector3.forward * Time.deltaTime );
		transform.Translate( strafe * Vector3.right * Time.deltaTime );

		if( Input.GetButtonDown("Fire1") )
		{
			// Fire
		}
	}
}

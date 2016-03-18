using UnityEngine;
using System.Collections;

public class debugSphere : MonoBehaviour {

    private Rigidbody r;
	// Use this for initialization
	void Start () {
        r = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        r.velocity = 10f * new Vector3(moveH, 0.0f, moveV);
	}
}

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
        float moveH = 0.0f;
        if (Input.GetKey("h"))
        {
            moveH = 2.0f;
        }

        float moveV = 0.0f;
        if (Input.GetKey("v"))
        {
            moveV = 2.0f;
        }
        r.velocity = 10f * new Vector3(moveH, 0.0f, moveV);
	}
}

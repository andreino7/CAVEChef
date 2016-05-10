using UnityEngine;
using System.Collections;

public class ElbowWristPointer : MonoBehaviour {

    public GameObject elbow;
    public GameObject wrist;



	// Use this for initialization
	void Awake () {
        transform.LookAt(wrist.transform);
        elbow.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(wrist.transform);
	
	}
}

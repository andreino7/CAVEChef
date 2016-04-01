﻿using UnityEngine;
using System.Collections;

public class MovableObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Gabber")){	
			//transform.localScale = transform.localScale * 1.5;
			transform.parent = other.gameObject.transform;
			GetComponent<Rigidbody>().isKinematic = true;
			GameController.instance.showCabinet();
		}
		if (other.gameObject.CompareTag("GoalObject")){	
			//transform.localScale = transform.localScale * 1.5;
			GetComponentInChildren<ParticleSystem>().Play();
			Destroy(gameObject,GetComponentInChildren<ParticleSystem>().duration);
		}
	}
}

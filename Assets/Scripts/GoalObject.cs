using UnityEngine;
using System.Collections;

public class GoalObject : MonoBehaviour {
	public ParticleSystem winParticles;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Ethan")){	
			//transform.localScale = transform.localScale * 1.5;
			winParticles.transform.parent = null;
			winParticles.Play();
			Destroy(gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class FootstepsPlayer : MonoBehaviour {

	public AudioSource footstepSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collision) {

		if (collision.gameObject.CompareTag("FootPadPresser")) {
			footstepSound.Play();
		}

	}
}

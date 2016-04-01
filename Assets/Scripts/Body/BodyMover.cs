using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BodyMover : MonoBehaviour {

	List<BodyPart> bodyParts = new List<BodyPart>(); 
	// Use this for initialization
	private bool triggerBody;

	void Start () {
		GameObject[] containers = GameObject.FindGameObjectsWithTag("Containers");
		foreach(GameObject g in containers) {
			foreach(Transform t in g.transform) {
				bodyParts.Add(new BodyPart(g, t.gameObject.tag));
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach(BodyPart b in bodyParts) {
			b.UpdateBodyPart();
		}
		if(triggerBody) {
			foreach(BodyPart b in bodyParts) {
				b.ComputeOffset();
			}
			foreach(BodyPart b in bodyParts) {
				b.UpdateScale();
			}

			triggerBody = false;
		}
	/*	foreach(GameObject g in GameObject.FindGameObjectsWithTag("Shoulders")) {
			g.GetComponent<Scaler>().UpdateScale();
		}*/
	}

	public void SetTrigger() {
		triggerBody = true;
	}



}

using UnityEngine;
using System.Collections;

public class TriggerBody : MonoBehaviour {

	private LegMover legMover;
	public GameObject body;
	// Use this for initialization
	void Awake () {
		legMover = body.GetComponent<LegMover>();
	}
	
	// Update is called once per frame
	void Update () {
		if(CAVE2Manager.GetButtonDown(1, CAVE2Manager.Button.Button3)) {
			legMover.SetTrigger();
		}
	}
}

using UnityEngine;
using System.Collections;

public class TriggerBody : MonoBehaviour {

	public BodyMover bodyMover;
	public HipMover hipMover;
	public UpperBodyScaler hipScaler;
//	public LegMover legMover;

	
	// Update is called once per frame
	void Update () {
		if(CAVE2Manager.GetButtonDown(1, CAVE2Manager.Button.Button3)) {
			bodyMover.SetTrigger();
			hipMover.SetTrigger();
			hipScaler.ScaleUpperBody();
			//legMover.SetTrigger();
		}

		if(CAVE2Manager.GetButtonDown(1, CAVE2Manager.Button.Button2)) {
			getRealCameraUpdater.UpdateCameraFromWand();
		}
	}
}

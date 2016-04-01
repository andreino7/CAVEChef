using UnityEngine;
using System.Collections;

public class BodyScaler : MonoBehaviour {

	public GameObject rightLeg;
	public GameObject leftLeg;

	private float hipsLength;

	void Start() {
		hipsLength = (rightLeg.transform.parent.transform.position - leftLeg.transform.parent.transform.position).magnitude;
	}
	// Use this for initialization
	public void ScaleBody() {
		transform.localScale = new Vector3( (rightLeg.transform.parent.transform.position - leftLeg.transform.parent.transform.position).magnitude / hipsLength,1f,1f);
	}
}

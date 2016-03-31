using UnityEngine;
using System.Collections;

public class UpperBodyScaler : MonoBehaviour {

	public GameObject rightShoulder;
	public GameObject rightLeg;
	private float hipLength;

	// Use this for initialization
	void Start () {
		hipLength = (rightShoulder.transform.position - rightLeg.transform.position).magnitude;
	}
	
	// Update is called once per frame
	public void ScaleUpperBody() {
		transform.localScale = new Vector3((rightShoulder.transform.position - rightLeg.transform.position).magnitude / hipLength, 1f,1f);
	}
}

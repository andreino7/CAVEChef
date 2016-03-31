using UnityEngine;
using System.Collections;

public class Scaler : MonoBehaviour {

	public GameObject scaleTarget;
	private float length;

	void Start() {
		if(scaleTarget!=null) {
			length = (transform.position - scaleTarget.transform.position).magnitude;
		}
	}


	public void UpdateScale() {
		if(scaleTarget!=null) {
			transform.localScale = new Vector3(1f,(transform.position - scaleTarget.transform.position).magnitude / length, 1f);
		}
	}
}

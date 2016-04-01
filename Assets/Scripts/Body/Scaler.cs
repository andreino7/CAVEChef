using UnityEngine;
using System.Collections;

public class Scaler : MonoBehaviour {

	public GameObject scaleTarget;
	private float length;

	void Start() {
		if(scaleTarget!=null) {
			length = (transform.parent.transform.position - scaleTarget.transform.parent.transform.position).magnitude;
		}
	}


	public void UpdateScale() {
		if(scaleTarget!=null && isActiveAndEnabled) {
			float scale = (transform.parent.transform.position - scaleTarget.transform.parent.transform.position).magnitude / length;
			GameObject pointer = Instantiate(new GameObject());
			pointer.transform.parent = transform.parent;
			pointer.transform.position = transform.position;
			pointer.transform.LookAt(scaleTarget.transform);
			transform.localScale = new Vector3(1f,1f,1f);
			transform.parent = pointer.transform;
			Debug.Log(gameObject.tag);
			pointer.transform.localScale = new Vector3(scale, 1f, 1f);
			transform.parent = pointer.transform.parent;
			Destroy(pointer);
		}
	}
}

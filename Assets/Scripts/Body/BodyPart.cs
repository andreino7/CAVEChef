using UnityEngine;
using System.Collections;

public class BodyPart {
	private GameObject bodyPart;
	private Quaternion partOffset;
	private Quaternion targetRotation;
	private string sensor;
	private Scaler scaler;


	public BodyPart(GameObject bodyPart, string sensor) {
		this.bodyPart = bodyPart;
		targetRotation = bodyPart.transform.rotation;
		this.sensor = sensor;
		this.scaler = bodyPart.GetComponentInChildren<Scaler>();
	}


	public void UpdateBodyPart() {
		bodyPart.transform.position = getReal3D.Input.GetSensor(sensor).position;
		bodyPart.transform.rotation = getReal3D.Input.GetSensor(sensor).rotation * partOffset;
	}

	public void UpdateScale() {
		scaler.UpdateScale();
	}

	public void ComputeOffset() {
		Debug.Log (sensor);
		Debug.Log(getReal3D.Input.GetSensor(sensor).rotation);
		partOffset = Quaternion.Inverse(getReal3D.Input.GetSensor(sensor).rotation) * targetRotation;
	}




}

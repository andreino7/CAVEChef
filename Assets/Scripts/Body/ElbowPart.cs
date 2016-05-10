using UnityEngine;
using System.Collections;

public class ElbowPart : BodyPart {


	public ElbowPart(GameObject bodyPart, string sensor) : base(bodyPart, sensor) {
	}


	public virtual void UpdateBodyPart() {
		bodyPart.transform.position = getReal3D.Input.GetSensor(sensor).position;
	}



}

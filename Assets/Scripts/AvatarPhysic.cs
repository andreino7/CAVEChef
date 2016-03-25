using UnityEngine;
using System.Collections;

public class AvatarPhysic : MonoBehaviour {

	private Vector3 m_Velocity = new Vector3();
	private Vector3 m_Acceleration = new Vector3();
	private Vector3 m_OldPosition = new Vector3();

	// Use this for initialization
	void Start () {
		m_OldPosition = transform.position;
		Update();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 oldVelocity = m_Velocity;
		//Debug.Log ("ethanposition" + transform.position);
		//Debug.Log ("velocity1" + m_Velocity);
		if(Time.deltaTime > 0) {
			m_Velocity = (transform.position - m_OldPosition) / Time.deltaTime;
		}
		//Debug.Log("time" + Time.deltaTime);
		//Debug.Log("velocity2" + m_Velocity);
		//m_Acceleration = (m_Velocity - oldVelocity)/Time.deltaTime;
		m_OldPosition = transform.position;
	}

	public Vector3 GetVelocity() {
		return m_Velocity;
	}

	public Vector3 GetAcceleration() {
		return m_Acceleration;
	}
}

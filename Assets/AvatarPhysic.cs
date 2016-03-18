using UnityEngine;
using System.Collections;

public class AvatarPhysic : MonoBehaviour {

	private Vector3 m_Velocity = 0f;
	private Vector3 m_Acceleration = 0f;
	private Vector3 m_OldPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 oldVelocity = m_Velocity;
		m_Velocity = (transform.position - m_OldPosition) / Time.deltaTime;
		m_Acceleration = m_Velocity - oldVelocity;
		m_OldPosition = transform.position;
	}

	public Vector3 GetVelocity() {
		return m_Velocity;
	}

	public Vector3 GetAcceleration() {
		return m_Acceleration;
	}
}

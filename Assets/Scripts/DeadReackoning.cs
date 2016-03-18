using UnityEngine;
using System.Collections;

public class DeadReackoning : MonoBehaviour {

	public GameObject m_Player;
	private AvatarPhysic m_AvatarPhysic;
	private float m_StartTime;
	private Vector3 m_Velocity;
	private float m_Journey;
	private Vector3 m_StartPosition;
	private Vector3 m_EndPosition;

	void Awake() {
		m_Player = GameObject.FindGameObjectWithTag ("Ethan");
		m_AvatarPhysic = m_Player.GetComponent<AvatarPhysic> ();
	}

	// Use this for initialization
	void Start () {
		m_StartTime = Time.time;
		Vector3 playerPosition = m_Player.transform.position;
		Vector3 distance = Vector3.Distance (transform.position, playerPosition);
		float time = Mathf.Sqrt (2 * distance / Physics.gravity);
		m_EndPosition = playerPosition + m_AvatarPhysic.GetVelocity()*time + m_AvatarPhysic.GetAcceleration()*time*time;
		transform.LookAt (m_EndPosition);
		m_Journey = Vector3.Distance (transform.position, m_EndPosition); 
	}
	
	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - m_StartTime) * m_Velocity.magnitude;
		float fracJourney = distCovered / m_Journey;
		transform.position = Vector3.Lerp (m_StartPosition, m_EndPosition, fracJourney);
	}


}

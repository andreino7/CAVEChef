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
	private float m_CurrentTime;
	private float m_TotalTime;

	void Awake() {
		m_Player = GameObject.FindGameObjectWithTag ("Ethan");
		m_AvatarPhysic = m_Player.GetComponent<AvatarPhysic> ();
	}

	// Use this for initialization
	void Start () {
		m_StartTime = Time.time;
		Vector3 playerPosition = m_Player.transform.position;
		m_StartPosition = transform.position;
		float distance = Mathf.Abs(-transform.position.y + playerPosition.y);
		Debug.Log("Distance" + distance);
		m_TotalTime = Mathf.Sqrt (2 * distance );
		Debug.Log("Time" + m_TotalTime);
//		Debug.Log("Time" + time);
		Debug.Log("velocity" + m_AvatarPhysic.GetVelocity());
		//Debug.Log("acceleration" + m_AvatarPhysic.GetAcceleration());
		m_EndPosition = playerPosition + m_AvatarPhysic.GetVelocity()*m_TotalTime;
		Debug.Log("end position" + m_EndPosition);
		transform.LookAt (m_EndPosition);
		m_Journey = Vector3.Distance (transform.position, m_EndPosition); 
		//Debug.Log("journey" + m_Journey);
		m_CurrentTime = Time.time;
		Destroy(gameObject,5f);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("porco dio");
		//Debug.Log (m_AvatarPhysic.GetVelocity());
		//Debug.Log (m_EndPosition);
		m_CurrentTime += Time.deltaTime;
		float timeTmp = m_CurrentTime - m_StartTime;
		Vector3 direction = m_EndPosition - transform.position;
		//Vector3 acc = Vector3.Project(new Vector3(0f,-1f,0f), direction);
//		transform.position = transform.position + acc*0.5f*timeTmp*timeTmp;
		//Debug.Log(transform.position);
		Vector3 acc = new Vector3(0f,-1f,0f);
		float y = (transform.position + acc*0.5f*timeTmp*timeTmp).y;
		float x = m_StartPosition.x + (m_EndPosition.x - m_StartPosition.x ) * timeTmp / m_TotalTime;
		float z = m_StartPosition.z + ( m_EndPosition.z - m_StartPosition.z) * timeTmp / m_TotalTime;
		transform.position = new Vector3(x,transform.position.y,z);
		if(y <= 0) {
			Debug.Log("minore");
			Debug.Log (transform.position);
			Destroy(gameObject);
		}
		//Debug.Log(distCovered);
		//float fracJourney = distCovered / m_Journey;
		//Debug.Log(fracJourney);
		//transform.position = Vector3.Lerp (m_StartPosition, m_EndPosition, fracJourney);
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Ethan")) {
			CaveChefGameController.GetController().AddPoints(-5);
		}
	}


}

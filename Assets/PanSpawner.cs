using UnityEngine;
using System.Collections;

public class PanSpawner : MonoBehaviour {

	public GameObject m_PanPrefab;
	private bool m_AlreadyGenerated;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider other) {
		if (other.tag == "Ethan" && !m_AlreadyGenerated) {
			Instantiate(m_PanPrefab, new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z), transform.rotation);
			m_AlreadyGenerated = true;
		}
	}

	public void OnTriggerExit(Collider other) {
		if (other.tag == "Ethan") {
			m_AlreadyGenerated = false;
		}
	}
}

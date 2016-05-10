using UnityEngine;
using System.Collections;

public class MovableObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Glower g = GetComponentInChildren<Glower>();
        if (g != null)
        {
            g.enabled=true;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Gabber") && isActiveAndEnabled){	
			//transform.localScale = transform.localScale * 1.5;
			transform.parent = other.gameObject.transform;
			GetComponent<Rigidbody>().isKinematic = true;
            //GameController.instance.showCabinet();
            Glower g = GetComponentInChildren<Glower>();
            if (g != null)
            {
                g.Reset();
                g.enabled = false;
            }
        }
        if (other.gameObject.CompareTag("GoalObject") && isActiveAndEnabled)
        {	
			//transform.localScale = transform.localScale * 1.5;
			GetComponentInChildren<ParticleSystem>().Play();
			Destroy(gameObject,GetComponentInChildren<ParticleSystem>().duration);
		}
	}
}

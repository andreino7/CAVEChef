using UnityEngine;
using System.Collections;

public class Kickable : MonoBehaviour {

    private bool flying = false;
    private Rigidbody rb;
    public float FootObjectMassRatio = 2;

    public float respawnTime = 2f;
    private float timeFlying = 0f;

    private Vector3 startPos;
    private Quaternion startRot;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        startRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	    if (flying)
        {
            timeFlying += Time.deltaTime;
            if (timeFlying > respawnTime)
            {
                timeFlying = 0;
                flying = false;
                transform.position = startPos;
                transform.rotation = startRot;
                rb.isKinematic = true;
            }
        }
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("FootPadPresser") && !flying) {
			float sp = other.gameObject.GetComponent<VelocityCalculator> ().speed;
            Vector3 dir = other.gameObject.GetComponent<VelocityCalculator>().direction;
            rb.isKinematic = false;
            rb.AddForce(dir * sp*FootObjectMassRatio,ForceMode.Impulse);
            Debug.Log(dir * sp * FootObjectMassRatio);
            flying = true;
		}
	}
}

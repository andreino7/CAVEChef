using UnityEngine;
using System.Collections;

public class ShoulderAligner : MonoBehaviour {

    public Transform elbow;
    public Transform[] partsToRaise;
    public float[] startPositions;

    private float elbowStartY;
    private float deltaFromElbow;

	// Use this for initialization
	void Start () {
        elbowStartY = elbow.position.y;
        startPositions = new float[partsToRaise.Length];
        for (int i = 0; i < partsToRaise.Length; i++)
        {
            Transform t = partsToRaise[i];
            startPositions[i] = t.position.y;
        }

        //deltaFromElbow = elbow.position.y - transform.position.y;
	}
	
	public void Align(){
        //transform.position = new Vector3(transform.position.x, elbow.position.y - deltaFromElbow, transform.position.z);
        float deltaTot = elbow.position.y - elbowStartY;
        float deltaCum = 0;
        for (int i = 0; i < partsToRaise.Length; i++)
        {
            deltaCum += (deltaTot / partsToRaise.Length);
            Transform t = partsToRaise[i];
            t.position = new Vector3(t.position.x, startPositions[i] + deltaCum, t.position.z);
        }
        

    }
}

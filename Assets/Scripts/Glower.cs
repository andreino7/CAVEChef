using UnityEngine;
using System.Collections;

public class Glower : MonoBehaviour {

    public float glowPeriod = 2f;
    public float glowProgress = 0f;

    public float glowStart = 0;
    public float glowEnd = 5;

	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
        glowProgress += Time.deltaTime;
        float prog;
        if (glowProgress < glowPeriod / 2)
        {
            prog = glowStart + ((glowEnd - glowStart) * (glowProgress / (glowPeriod / 2)));
        } else if (glowProgress <= glowPeriod)
        {
            prog = glowEnd - ((glowEnd - glowStart) * ((glowProgress- glowPeriod/2) / (glowPeriod / 2)));
        }
        else
        {
            glowProgress = 0;
            prog = glowStart;
        }


        GetComponent<Renderer>().material.SetFloat("_MKGlowTexStrength", prog);

    }

    public void Reset()
    {
        GetComponent<Renderer>().material.SetFloat("_MKGlowTexStrength", glowStart);
    }
}

using UnityEngine;
using System.Collections;

public class KittenAI : MonoBehaviour {

	Animation an;

	// Use this for initialization
	void Start () {

		an = GetComponent<Animation>();
		an["Walk"].layer = 1;
		an.Play ("Walk");
	}
	
	// Update is called once per frame
	void Update () {

	}
}


public class CatState{
	Animation an;

}
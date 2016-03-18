using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject cabinet;
	public GameObject trap;

	public static GameController instance;



	// Use this for initialization
	void Awake(){
		instance = this;
	}


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showCabinet(){
		cabinet.SetActive(true);
		trap.SetActive(true);
	}

	private GameController(){

	}
}

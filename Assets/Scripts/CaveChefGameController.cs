using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CaveChefGameController : MonoBehaviour {

	private static CaveChefGameController instance;
	public GameObject[] levels;
	public Text messagePanel;

	private int level = 0;

	void Awake(){
		if (instance == null){
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		levels [level].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static CaveChefGameController GetController(){
		

		return instance;
	}

	public void showMessage(string msg){
		messagePanel.text = msg;
	}

	public void nextLevel(){
		level += 1;
		levels [level].SetActive (true);
	}


}

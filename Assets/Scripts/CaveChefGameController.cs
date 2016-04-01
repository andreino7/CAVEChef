using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CaveChefGameController : MonoBehaviour {

	private static CaveChefGameController instance;
	public GameObject[] levels;
	public Text messagePanel;
	public Text scoreText;
	public Text timeText;
	public Text gameOverText;
	public GameObject panel;
	private float time = 120f;
	private int score = 0;

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
		UpdateTime();
	}

	public static CaveChefGameController GetController(){
		return instance;
	}

	private void UpdateTime() {
		time -= Time.deltaTime;
		timeText.text = "TIME: " + (int) time;
		if(time <= 0) {
			gameOverText.gameObject.SetActive(true);
			panel.SetActive(true);
		}
	}

	public void showMessage(string msg){
		messagePanel.text = msg;
	}

	public void nextLevel(){
		level += 1;
		levels [level].SetActive (true);
	}

	public void AddPoints(int points) {
		score += points;
		UpdateScore();
	}

	private void UpdateScore() {
		scoreText.text = "SCORE: " + score;
	}


}

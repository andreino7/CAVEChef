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
	public Text welcomeText;
	public GameObject welcomePanel;
	public AudioSource littleWinSound;
	public AudioSource timerCountDownSound;
	public AudioSource winSound;
	private bool hasWon = false;
	private bool countdown = false;
	private float time = 120f;
	private int score = 0;
	public Text winningText;


	private int level = 0;

	void Awake(){
		if (instance == null){
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		Destroy (welcomePanel, 5);
		Destroy (welcomeText.gameObject, 5);
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
		if (time <= 10 && !countdown) {
			countdown = true;
			timerCountDownSound.Play ();
		}
		if(time <= 0 && !hasWon) {
			gameOverText.gameObject.SetActive(true);
			panel.SetActive(true);
			timerCountDownSound.Stop ();
		}
	}

	public void showMessage(string msg){
		messagePanel.text = msg;
	}

	public void nextLevel(){
		littleWinSound.Play ();
		level += 1;
        if (level >= levels.Length)
        {
            GameEnded();
        }
        else
        {
            levels[level].SetActive(true);
        }

	}

	public void AddPoints(int points) {
		score += points;
		UpdateScore();
	}

	public void GameEnded() {
		hasWon = true;
		panel.SetActive(true);
		winningText.text = winningText.text + score;
		winningText.gameObject.SetActive(true);
		timerCountDownSound.Stop ();
		winSound.Play();


	}

	private void UpdateScore() {
		scoreText.text = "SCORE: " + score;
	}


}

using UnityEngine;
using System.Collections;

public class GoalBringGameScript : MonoBehaviour {

	public GameObject objectToBeBrought;
	public string startGameDialog = "Bring The Object to The Object";
	public string endGameDialog = "Good Job!";
	public GameObject before;
	public GameObject after;
	public GameObject[] obstacles;

	// Use this for initialization
	void Start () {
		CaveChefGameController.GetController ().showMessage (startGameDialog);
		foreach(GameObject g in obstacles) {
			g.SetActive(true);
		}
        objectToBeBrought.SetActive(true);

       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject == objectToBeBrought) {
			//Goal Reached;
			Destroy(objectToBeBrought);
			Destroy(before);
			after.SetActive (true);
			CaveChefGameController.GetController ().showMessage (endGameDialog);
			StartCoroutine (ExecuteAfterTime (1));

		}
	}

	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds(time);

        CaveChefGameController.GetController().AddPoints(5);
        CaveChefGameController.GetController ().nextLevel ();
		// Code to execute after the delay
	}
}

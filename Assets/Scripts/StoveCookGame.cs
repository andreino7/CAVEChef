using UnityEngine;
using System.Collections;

public class StoveCookGame : MonoBehaviour {

	public GameObject objectToBeBrought;
	public GameObject duringCooking;
	public GameObject cookedObject;
	public string startGameDialog = "Bring the Object to the Stove";
	public string onStoveDialog = "Good Job, it will take ";
	public string readyMsg = "The Object is cooked";
	public string burnMsg = "The Object is burning";

	public int cookTime = 60;
	public int burnTime = 30;


	private float cookDuration = 0;
	private bool cooking = false;
	private bool cooked = false;



	// Use this for initialization
	void Start () {
		CaveChefGameController.GetController ().showMessage (startGameDialog);
	}

	// Update is called once per frame
	void Update () {

		if (cooking) {
			cookDuration += Time.deltaTime;
		}


		if (cookDuration > cookTime + burnTime) {
			CaveChefGameController.GetController ().showMessage (burnMsg);
		}else if (cookDuration > cookTime) {
			if (!cooked) {
				cooked = true;
				Destroy (duringCooking);
				cookedObject.SetActive (true);
				CaveChefGameController.GetController ().showMessage (readyMsg);
			}
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject == objectToBeBrought) {
			//Stove Reached;
			Destroy(objectToBeBrought);
			duringCooking.SetActive (true);
			CaveChefGameController.GetController ().showMessage (onStoveDialog + Mathf.Floor(cookTime/1) + " sec");
			cooking = true;
			cookDuration = 0;
		}
	}
}

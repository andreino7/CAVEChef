using UnityEngine;
using System.Collections;

public class MealReady : MonoBehaviour {

	public GameObject target;
	public GameObject newPan;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject == target) {
			newPan.SetActive(true);
			target.SetActive(false);
			CaveChefGameController.GetController().AddPoints(10);
			CaveChefGameController.GetController().GameEnded();
		}
	}
}

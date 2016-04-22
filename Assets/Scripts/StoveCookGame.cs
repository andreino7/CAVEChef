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
	public AudioSource stoveSound;
	public AudioSource objectReadySound;
	public GameObject smokeEffectPrefab;
	public GameObject smokeEffect;
    public GameObject flameEffect;
    public int cookTime = 60;
	public int burnTime = 30;

	private bool smokeGenerated = false;
	private float cookDuration = 0;
	private bool cooking = false;
	private bool cooked = false;
	private int damage = -5;
	private float damageInterval = 5f;
	private float lastBurned = 0f;


	// Use this for initialization
	void Start () {
		CaveChefGameController.GetController ().showMessage (startGameDialog);
        objectToBeBrought.GetComponent<MovableObject>().enabled = true;
	}

	// Update is called once per frame
	void Update () {

		if (cooking) {
			cookDuration += Time.deltaTime;
		}


		if (cookDuration > cookTime + burnTime) {
			CaveChefGameController.GetController ().showMessage (burnMsg);
			if(Time.time > lastBurned + damageInterval) {
				if(!smokeGenerated) {
					smokeEffect = (GameObject) Instantiate(smokeEffectPrefab, cookedObject.transform.position, smokeEffectPrefab.transform.rotation);
					smokeGenerated = true;
				}

				lastBurned = Time.time;
				CaveChefGameController.GetController ().AddPoints (damage);
			}
		}else if (cookDuration > cookTime) {
			if (!cooked) {
				objectReadySound.Play ();
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
			CaveChefGameController.GetController ().AddPoints(damage*-1);
			stoveSound.Play ();
            flameEffect.SetActive(true);

        }
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject == cookedObject) {
            CaveChefGameController.GetController().nextLevel();
            Destroy(smokeEffect);
            Destroy(flameEffect);
			Destroy(this);
		}
	}
}

using UnityEngine;
using System.Collections;

public class KickInCabinetGame : MonoBehaviour {

    public Transform cabinetRotator;
    public Vector3 openRot;
    public Vector3 closedRot;
    public GameObject objectToKick;

    public string startGameDialog = "Kick the Object into the cabinet";
    public string endGameDialog = "Good Job!";

    // Use this for initialization
    void Start () {
        objectToKick.SetActive(true);
        cabinetRotator.rotation = Quaternion.Euler(openRot);
        CaveChefGameController.GetController().showMessage(startGameDialog);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == objectToKick)
        {
            Destroy(objectToKick);
            cabinetRotator.rotation = Quaternion.Euler(closedRot);
            CaveChefGameController.GetController().showMessage(endGameDialog);
            CaveChefGameController.GetController().AddPoints(10);
            gameObject.SetActive(false);

            CaveChefGameController.GetController().nextLevel();
        }
    }
}

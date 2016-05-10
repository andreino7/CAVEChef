using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStarter : MonoBehaviour {

    public GameObject startPanel;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 10);
        Destroy(startPanel, 10);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

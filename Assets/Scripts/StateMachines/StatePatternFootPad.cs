using UnityEngine;
using System.Collections;

public class StatePatternFootPad : MonoBehaviour {

	int stepCount= 0;
	int nOfSteps = 2;
	public string startGameDialog;
    public bool rightLegNext = true;
    public float stepRight = 0.2f;
    public float stepLeft = -0.2f;
    public float stepFront = 0.2f;
    public float stepBack = -0.2f;
    [HideInInspector] public IFootPadState currentState;
    [HideInInspector] public RightState rightState;
    [HideInInspector] public LeftState leftState;
    [HideInInspector] public FrontState frontState;
    [HideInInspector] public BackState backState;

    private void Awake ()
    {
        frontState = new FrontState(this);
        backState = new BackState(this);
        rightState = new RightState(this);
        leftState = new LeftState(this);
  
    }
	// Use this for initialization
	void Start () {
        currentState = leftState;
        rightLegNext = true;
		CaveChefGameController.GetController ().showMessage (startGameDialog);
    }
	
	// Update is called once per frame
	void Update () {
        currentState.UpdateState();
	}

    private void OnTriggerEnter (Collider other)
    {
		Debug.Log (other.gameObject.tag);
		if(other.gameObject.CompareTag("FootPadPresser")) {
			stepCount++;
			if (stepCount > nOfSteps){
				CaveChefGameController.GetController().nextLevel();	
				CaveChefGameController.GetController().AddPoints(10);
				Destroy(gameObject);
			}else{
        		currentState.OnTriggerEnter(other);
			}
		}
    }

    public void toggleLeg()
    {
        rightLegNext = !rightLegNext;
    }
}

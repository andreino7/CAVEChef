using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class KittenAI : MonoBehaviour {

	Animation an;
	CatState state;
	Rigidbody rb;
	public AudioSource meowSound;
	//float catSpeed = 3f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		an = GetComponent<Animation>();
		ProbTable.populateTable ();

		state = new CatState ("Idle", "Idle",an);

	}
	
	// Update is called once per frame
	void Update () {

		state.time += Time.deltaTime;

		if (state.time > state.dur) {
			state = state.next ();
			if (state.current == "Meow") {
				meowSound.Play ();
			}
			if (state.current == "Walk") {
				
				rb.velocity = new Vector3 (-0.5f + UnityEngine.Random.value, 0, -0.5f + UnityEngine.Random.value).normalized;

				transform.forward = rb.velocity;
			} else {
				rb.velocity = Vector3.zero;
			}
			rb.angularVelocity = Vector3.zero;
		}

	}
}

public class PrecStates : IEquatable<PrecStates>{
	public string old1,old2;
	public PrecStates (string o1, string o2){
		old1 = o1;
		old2 = o2;
	}

	public override int GetHashCode() {
		return old1.GetHashCode() + old2.GetHashCode();
	}
	public override bool Equals(object obj) {
		return Equals(obj as PrecStates);
	}
	public bool Equals(PrecStates obj) {
		return obj != null && obj.old1 == this.old1 && obj.old2 == this.old2;
	}
}

public class NextState{
	public string state;
	public float prob;

	public NextState(string s, float p){
		state = s;
		prob = p;
	}
}

public class ProbTable{

	public static Dictionary<PrecStates,NextState[]> probabilities = new Dictionary<PrecStates,NextState[]>();

	public static void populateTable(){
		probabilities[new PrecStates("Idle","Walk")] = new NextState[] {new NextState("Idle",0.5f), new NextState("Walk",0.3f), new NextState("Meow",0.1f), new NextState("Ithcing",0.1f)};
		probabilities[new PrecStates("Idle","Idle")] = new NextState[] {new NextState("Idle",0.3f), new NextState("Walk",0.5f), new NextState("Meow",0.0f), new NextState("Ithcing",0.2f)};
		probabilities[new PrecStates("Idle","Meow")] = new NextState[] {new NextState("Idle",0.6f), new NextState("Walk",0.3f), new NextState("Meow",0.0f), new NextState("Ithcing",0.1f)};
		probabilities[new PrecStates("Idle","Ithcing")] = new NextState[] {new NextState("Idle",0.5f), new NextState("Walk",0.25f), new NextState("Meow",0.2f), new NextState("Ithcing",0.05f)};

		probabilities[new PrecStates("Walk","Walk")] = new NextState[] {new NextState("Idle",0.4f), new NextState("Walk",0.4f), new NextState("Meow",0.1f), new NextState("Ithcing",0.1f)};
		probabilities[new PrecStates("Walk","Idle")] = new NextState[] {new NextState("Idle",0.4f), new NextState("Walk",0.3f), new NextState("Meow",0.2f), new NextState("Ithcing",0.1f)};
		probabilities[new PrecStates("Walk","Meow")] = new NextState[] {new NextState("Idle",0.4f), new NextState("Walk",0.5f), new NextState("Meow",0.0f), new NextState("Ithcing",0.1f)};
		probabilities[new PrecStates("Walk","Ithcing")] = new NextState[] {new NextState("Idle",0.4f), new NextState("Walk",0.3f), new NextState("Meow",0.2f), new NextState("Ithcing",0.1f)};

		probabilities[new PrecStates("Meow","Walk")] = new NextState[] {new NextState("Idle",0.7f), new NextState("Walk",0.1f), new NextState("Meow",0.1f), new NextState("Ithcing",0.1f)};
		probabilities[new PrecStates("Meow","Idle")] = new NextState[] {new NextState("Idle",0.4f), new NextState("Walk",0.3f), new NextState("Meow",0.2f), new NextState("Ithcing",0.1f)};
		probabilities[new PrecStates("Meow","Meow")] = new NextState[] {new NextState("Idle",0.8f), new NextState("Walk",0.1f), new NextState("Meow",0.0f), new NextState("Ithcing",0.1f)};
		probabilities[new PrecStates("Meow","Ithcing")] = new NextState[] {new NextState("Idle",0.4f), new NextState("Walk",0.3f), new NextState("Meow",0.2f), new NextState("Ithcing",0.1f)};
	
		probabilities[new PrecStates("Ithcing","Walk")] = new NextState[] {new NextState("Idle",0.7f), new NextState("Walk",0.1f), new NextState("Meow",0.1f), new NextState("Ithcing",0.1f)};
		probabilities[new PrecStates("Ithcing","Idle")] = new NextState[] {new NextState("Idle",0.4f), new NextState("Walk",0.3f), new NextState("Meow",0.2f), new NextState("Ithcing",0.1f)};
		probabilities[new PrecStates("Ithcing","Meow")] = new NextState[] {new NextState("Idle",0.8f), new NextState("Walk",0.1f), new NextState("Meow",0.0f), new NextState("Ithcing",0.1f)};
		probabilities[new PrecStates("Ithcing","Ithcing")] = new NextState[] {new NextState("Idle",0.4f), new NextState("Walk",0.3f), new NextState("Meow",0.2f), new NextState("Ithcing",0.1f)};

	}

}

public class CatState{
	Animation an;



	float minDur,maxDur;
	public float time;
	public float dur;
	string old;
	public string current;

	public CatState next(){
		float ran = UnityEngine.Random.value;
		float cumulative = 0;

		NextState[] possibilities = ProbTable.probabilities [new PrecStates (old, current)];

		int i = 0;
		while (i < possibilities.Length) {
			if (cumulative + possibilities [i].prob > ran) {
				break;
			} else {
				cumulative += possibilities [i].prob;
			}
			i++;
		}

		string next = possibilities [i].state;

		return new CatState(next, current, an);

	}

	public CatState(string state,string old1,Animation a) {
		current = state;
		old = old1;
		an = a;
		dur = an [state].length;
		an.Play (state);

	}


}
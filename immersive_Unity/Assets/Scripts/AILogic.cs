using UnityEngine;
using System.Collections;

public class AILogic : MonoBehaviour {
	private Animator anim;
	private CharacterInteract state;
	bool AiMoving; 
	// Use this for initialization
	void Start () {
		state = gameObject.GetComponent<CharacterInteract>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (AiMoving == true){
			anim.SetBool("isWalking", true);
		}
		else {
			anim.SetBool("isWalking", false);
		}
	}

	void StartWalking(){
		AiMoving = true;
	}

	void StopWalking(){
		AiMoving = false;
	}

	void LineCutterStop(){
		AiMoving = false;
		state.itemUseable = false;
	}
}

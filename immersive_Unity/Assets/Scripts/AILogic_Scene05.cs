using UnityEngine;
using System.Collections;

public class AILogic_Scene05 : MonoBehaviour {
	private Animator anim;
	private CharacterInteract_Scene_05 state;
	bool AiMoving; 
	// Use this for initialization
	void Start () {
		state = gameObject.GetComponent<CharacterInteract_Scene_05>();
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

	void AIStop(){
		AiMoving = false;
		state.itemUseable = false;
	}
}

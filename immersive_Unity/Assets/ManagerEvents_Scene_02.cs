using UnityEngine;
using System.Collections;

public class ManagerEvents_Scene_02 : MonoBehaviour {

	private Animator animManager;

	void Start(){
		animManager = GetComponent<Animator>();
	}

	void startWalking(){
		animManager.SetBool("isWalking", false);
	}
	
	void stopWalking(){
		
		animManager.SetBool("isWalking", false);
	}
}

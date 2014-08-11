using UnityEngine;
using System.Collections;

public class PlayerPathController_Scene_3 : MonoBehaviour {


	private CharacterInteract_Scene_3 AiInteract;

	// Use this for initialization
	void Start () {
		AiInteract = GameObject.Find ("carl").GetComponent<CharacterInteract_Scene_3> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnComplete(){

		AiInteract.itemUseable = false;
	}


}

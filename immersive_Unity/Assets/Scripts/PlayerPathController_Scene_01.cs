﻿using UnityEngine;
using System.Collections;

public class PlayerPathController_Scene_01 : MonoBehaviour {


	private CharacterInteract_Scene_01 AiInteract;

	// Use this for initialization
	void Start () {
		AiInteract = GameObject.Find ("FuseModel").GetComponent<CharacterInteract_Scene_01> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnComplete(){

		AiInteract.itemUseable = false;
	}
}

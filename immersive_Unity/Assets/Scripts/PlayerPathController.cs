using UnityEngine;
using System.Collections;

public class PlayerPathController : MonoBehaviour {


	private CharacterInteract AiInteract;
	// Use this for initialization
	void Start () {
		AiInteract = GameObject.Find ("carl").GetComponent<CharacterInteract> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnComplete(){

		AiInteract.itemUseable = false;
	}
}

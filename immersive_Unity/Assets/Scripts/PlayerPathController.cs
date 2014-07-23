using UnityEngine;
using System.Collections;

public class PlayerPathController : MonoBehaviour {


	private CharacterInteract_Scene_05 AiInteract;
	public GameObject Player;
	
	// Use this for initialization
	void Start () {
		AiInteract = GameObject.Find ("carl").GetComponent<CharacterInteract_Scene_05> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnComplete(){

		AiInteract.itemUseable = false;
	}
	
	IEnumerator  StartFade(){
		iTween.CameraFadeAdd ();
		//iTween.CameraFadeTo (0,1);
		iTween.CameraFadeFrom (1,6);

		yield return new WaitForSeconds(10.0F);

		OnComplete ();
	}
}

using UnityEngine;
using System.Collections;

[System.Serializable]
public class audio_Scene09_start {
	public AudioClip clip1;
}


public class PlayerPathController_Scene_09 : MonoBehaviour {


	private CharacterInteract_Scene_09 AiInteract;
	public GameObject Player;
	public audio_Scene09_start  audioStart;


	// Use this for initialization
	void Start () {
		AiInteract = GameObject.Find ("Antagonist").GetComponent<CharacterInteract_Scene_09> ();

		StartCoroutine ("StartIntro");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnComplete(){

		AiInteract.itemUseable = false;
	}
	
	IEnumerator  StartIntro(){
	

		audio.clip = audioStart.clip1;
		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);
	
		OnComplete ();
	}
}

using UnityEngine;
using System.Collections;

[System.Serializable]
public class audio_Scene07_start {
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;
	public AudioClip clip4;
	public AudioClip clip5;
}


public class PlayerPathController_Scene_07 : MonoBehaviour {


	private CharacterInteract_Scene_07 AiInteract;
	public GameObject Player;
	public audio_Scene07_start  audioStart;


	// Use this for initialization
	void Start () {
		AiInteract = GameObject.Find ("Antagonist").GetComponent<CharacterInteract_Scene_07> ();

		StartCoroutine ("StartIntro");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnComplete(){

		AiInteract.itemUseable = false;
	}
	
	IEnumerator  StartIntro(){
		/*
		audio.clip = audioStart.clip1;
		audio.Play ();
		yield return new WaitForSeconds(audio.clip.length);

		audio.clip = audioStart.clip2;
		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);
		*/
		audio.clip = audioStart.clip3;
		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);
		
		/*audio.clip = audioStart.clip4;
		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);
		
		audio.clip = audioStart.clip5;
		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);*/

		OnComplete ();
	}
}

using UnityEngine;
using System.Collections;

[System.Serializable]
public class audio_Scene04_start {
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;
}


public class PlayerPathController_Scene_04 : MonoBehaviour {


	private CharacterInteract_Scene_04 AiInteract;
	public GameObject Player;
	public audio_Scene04_start  audioStart;


	// Use this for initialization
	void Start () {
		AiInteract = GameObject.Find ("Antagonist").GetComponent<CharacterInteract_Scene_04> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnComplete(){

		AiInteract.itemUseable = false;
	}
	
	IEnumerator  StartFade(){
		audio.Play ();

		yield return new WaitForSeconds(4.0F);

		audio.clip = audioStart.clip1;
		audio.Play ();

		yield return new WaitForSeconds(5.5F);

		iTween.CameraFadeAdd ();
		//iTween.CameraFadeTo (0,1);
		iTween.CameraFadeFrom (1,6);
		yield return new WaitForSeconds(6.0F);
		audio.clip = audioStart.clip2;
		audio.Play ();
		yield return new WaitForSeconds(4.0F);
		audio.clip = audioStart.clip3;
		audio.Play ();
		yield return new WaitForSeconds(4.0F);

		OnComplete ();
	}
}

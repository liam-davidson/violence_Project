using UnityEngine;
using System.Collections;

public class PlayerPathController : MonoBehaviour {


	private CharacterInteract_Scene_05 AiInteract;
	public GameObject Player;
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;

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
		audio.Play ();

		yield return new WaitForSeconds(4.0F);

		audio.clip = clip1;
		audio.Play ();

		yield return new WaitForSeconds(5.5F);

		iTween.CameraFadeAdd ();
		//iTween.CameraFadeTo (0,1);
		iTween.CameraFadeFrom (1,6);
		yield return new WaitForSeconds(6.0F);
		audio.clip = clip2;
		audio.Play ();
		yield return new WaitForSeconds(4.0F);
		audio.clip = clip3;
		audio.Play ();
		yield return new WaitForSeconds(4.0F);

		OnComplete ();
	}
}

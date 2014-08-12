using System.IO;
using System;

using UnityEngine;
using System.Collections;

[System.Serializable]
public class audio_Scene03_start {
	public AudioClip clip1;
}

[System.Serializable]
public class audio_Scene03_Threaten {
	public AudioClip clip_threaten;
	public AudioClip clip_threaten_2;
}

[System.Serializable]
public class audio_Scene03_Talk {
	public AudioClip clip_talk;
	public AudioClip clip_talk_2;
}

[System.Serializable]
public class audio_Scene03_Joke {
	public AudioClip clip_joke;
}

[System.Serializable]
public class audio_Scene03_Insult {
	public AudioClip clip_insult;
	public AudioClip clip_insult_2;
}

[System.Serializable]
public class audio_Scene03_Report {
	public AudioClip clip_report;
	public AudioClip clip_report_2;
}

public class CharacterResponses_Scene_3 : MonoBehaviour {
	public CharacterInteract_Scene_3 state;
	//public FocusOnPlayer aiLook;
	public GameObject AI;
	public DialogGUI_Scene_3 dialogue;
	public Transform targetLook;

	private Animator anim;
	private Animator animTV;
	private Animator animKitchen;
	public GameObject Player;

	public audio_Scene03_start audioStart;
	public audio_Scene03_Threaten audioThreaten;
	public audio_Scene03_Talk audioTalk;
	public audio_Scene03_Joke audioJoke;
	public audio_Scene03_Insult audioInsult;
	public audio_Scene03_Report audioReport;

	int choiceCounter;
	bool isSitting;
	string currentAiLocation;
	int maxChoiceNum;

	void Start() {
		anim = GetComponent<Animator>();
		//animTV = GameObject.Find("TVOn_0").GetComponent<Animator>();
		currentAiLocation = "default";
		maxChoiceNum = 2;
		//Player = GameObject.Find("FirstPersonController");
	}

	void Update(){

		//print (choiceCounter);

		if (choiceCounter == maxChoiceNum){
			iTween.CameraFadeAdd ();
			iTween.CameraFadeFrom (1,1);
			//Application.Quit();
			Application.LoadLevel ("Menu"); 
		}

		isSitting = anim.GetBool("isSitting");
		//print ("isSitting = " + isSitting);
		//print ("ChoiceCounter = " + choiceCounter);
		//print ("Current Location = " + currentAiLocation);

	}

	public void checkResponse(int caseNum){
		switch(caseNum){
		
		case 1:
			print ("case1 ACTIVATE!");

			//iTweenEvent.GetEvent(AI,"antag_leave").Play();
			//aiLook.enabled = false;
			//anim.SetBool("isWalking", true);

			choiceCounter++;
			LeaveDialog();
			break;
		
		case 2:
			print ("case2 ACTIVATE!");
			
			choiceCounter++;
			LeaveDialog();
			break;	
		
		case 3:
			print ("case3 ACTIVATE! THREATEN");

			StartCoroutine ("AudioThreaten");

			choiceCounter++;
			LeaveDialog();
			break;
		
		case 4:
			print ("case4 ACTIVATE!");

			iTweenEvent.GetEvent(Player,"protag_leave").Play();

			choiceCounter++;
			LeaveDialog();
			break;

		case 5:
			print ("case5 ACTIVATE!");

			iTweenEvent.GetEvent(Player,"protag_leave").Play();

			choiceCounter++;
			LeaveDialog();
			break;
			
		case 6:
			print ("case6 ACTIVATE!");

			StartCoroutine ("AudioJoke");

			//iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			//aiLook.enabled = false;
			//anim.SetBool("isWalking", true);

			choiceCounter++;
			LeaveDialog();
			break;	
			
		case 7:
			print ("case7 ACTIVATE!");

			StartCoroutine ("AudioInsult");

			choiceCounter++;
			LeaveDialog();
			break;
			
		case 8:
			print ("case8 ACTIVATE!");

			StartCoroutine("AudioTalk");

			choiceCounter++;
			LeaveDialog();
			break;

		case 9:
			print ("case9 ACTIVATE!");

			StartCoroutine("AudioReport");

			choiceCounter++;
			LeaveDialog();
			break;

		default:
			break;
		}
	}

	IEnumerator  AudioIntro(){
		audio.clip = audioStart.clip1;
		audio.Play ();
		
		yield return new WaitForSeconds(audio.clip.length);
		state.itemUseable = false;
	}

	IEnumerator AudioThreaten(){
		audio.clip = audioThreaten.clip_threaten;
		audio.Play ();

		yield return new WaitForSeconds (audio.clip.length);

		audio.clip = audioThreaten.clip_threaten_2;
		audio.Play ();

		state.itemUseable = false;
	}

	IEnumerator AudioTalk(){
		audio.clip = audioTalk.clip_talk;
		audio.Play ();

		yield return new WaitForSeconds (audio.clip.length);

		audio.clip = audioTalk.clip_talk_2;
		audio.Play ();

		state.itemUseable = false;
	}

	IEnumerator AudioJoke(){
		audio.clip = audioJoke.clip_joke;
		audio.Play ();

		yield return new WaitForSeconds (audio.clip.length);

		state.itemUseable = false;
	}

	IEnumerator AudioInsult(){
		audio.clip = audioInsult.clip_insult;
		audio.Play ();

		yield return new WaitForSeconds (audio.clip.length);

		audio.clip = audioInsult.clip_insult_2;
		audio.Play ();

		state.itemUseable = false;
	}
	
	IEnumerator AudioReport(){

		iTweenEvent.GetEvent(Player,"Manager_enter").Play();
		yield return new WaitForSeconds (7);

		audio.clip = audioReport.clip_report;
		audio.Play ();
		
		yield return new WaitForSeconds (audio.clip.length);

		audio.clip = audioReport.clip_report_2;
		audio.Play ();

		iTweenEvent.GetEvent(Player,"Manager_leave").Play();
		yield return new WaitForSeconds (7);

		state.itemUseable = false;
	}

	public void OnComplete(){
		state.itemUseable = false;
	}

	void AddToFile(){
		//StreamWriter sw = new StreamWriter("TestFile.txt");
		StreamWriter sw = File.AppendText ("TestFile.txt");
		sw.Write (",");
		sw.Write (choiceCounter);
		sw.Close ();
	}

	void LeaveDialog(){
		state.itemUseable = true;
		
		//GameObject.FindWithTag("Description").GetComponent<GUIText>().text = "";
		//GameObject.FindWithTag("Description").GetComponent<GUIText>().enabled = false;
		
		GameObject.FindWithTag("PlayerArms").GetComponent<Animation>().enabled = true;

		AddToFile();

		print("Exited Dialog!");
	}

	void StartIntro(){
		anim.SetBool("isWalking", false);
		StartCoroutine ("AudioIntro");

	}

	void StartWalking() {
		anim.SetBool("isWalking", true);
	}

	void eventEnd(){

		if (choiceCounter == maxChoiceNum){
			iTween.CameraFadeAdd ();
			iTween.CameraFadeFrom (1,1);
			//Application.Quit();
			Application.LoadLevel ("Menu"); 
		}
		
		anim.SetBool("isWalking", false);
		//Uncomment to let the AI look at you when he's done walking
		//aiLook.enabled = true;
	}
}

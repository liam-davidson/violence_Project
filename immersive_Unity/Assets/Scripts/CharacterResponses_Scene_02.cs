using System.IO;
using System;

using UnityEngine;
using System.Collections;

[System.Serializable]
public class audio_Scene02_ReportIt {
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;
	public AudioClip clip4;
	public AudioClip clip5;
}

[System.Serializable]
public class audio_Scene02_TalkItOut {
	public AudioClip clip1;
	public AudioClip clip2;
}

[System.Serializable]
public class audio_Scene02_Insult {
	public AudioClip clip1;
	public AudioClip clip2;
}

[System.Serializable]
public class audio_Scene02_Joke {
	public AudioClip clip1;
	public AudioClip clip2;
}

[System.Serializable]
public class audio_Scene02_Threaten {
	public AudioClip clip1;
	public AudioClip clip2;
}
[System.Serializable]
public class audio_Scene02_Ignore{
	public AudioClip clip1;
}
[System.Serializable]
public class audio_Scene02_Leave {
	public AudioClip clip1;
}


public class CharacterResponses_Scene_02 : MonoBehaviour {

	//TODO Change these to private
	public CharacterInteract_Scene_02 state;
	public FocusOnPlayer aiLook;
	public GameObject AI;
	public DialogGUI_Scene_02 dialogue;
	//public Transform targetLook;
	public GameObject Player;
	public GameObject Manager;
	
	private Animator anim;

	
	public audio_Scene02_ReportIt audioReportIt;
	public audio_Scene02_TalkItOut audioTalkItOut;
	public audio_Scene02_Insult audioInsult;
	public audio_Scene02_Joke audioJoke;
	public audio_Scene02_Threaten audioThreaten;
	public audio_Scene02_Ignore audioIgnore;
	public audio_Scene02_Leave audioLeave;

	int choiceCounter;
	bool isSitting;
	string currentAiLocation;
	int maxChoiceNum;

	void Start() {
		anim = GetComponent<Animator>();

		StartCoroutine("CutInLine");

		currentAiLocation = "default";
		maxChoiceNum = 2;
		//Player = GameObject.Find("FirstPersonController");
	}

	void Update(){

		isSitting = anim.GetBool("isSitting");
		print ("isSitting = " + isSitting);
		print ("ChoiceCounter = " + choiceCounter);
		print ("Current Location = " + currentAiLocation);

	}

	public void checkResponse(int caseNum){
		switch(caseNum){
		
		case 1:
			print ("case1 ACTIVATE!");
			GameObject.Find("radial_background").GetComponent<MeshRenderer>().enabled = false;
			GameObject.Find ("radial_background").GetComponentInChildren<MeshRenderer>().enabled = false;



		//	currentAiLocation = "TV";

			/*iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);
			anim.SetBool("interact", false);
			*/

			choiceCounter++;
			LeaveDialog();
			break;
		
		case 2:
			print ("case2 ACTIVATE!");


			if(isSitting == true){
				anim.SetBool("isSitting", false);
			}

			if (currentAiLocation == "default"){
				iTweenEvent.GetEvent(Player,"SideStepEvent").Play();
				iTweenEvent.GetEvent(Player,"MoveToKitchenEvent").Play();

				iTweenEvent.GetEvent(AI,"KitchenPathEvent").Play();

				anim.SetBool("isWalking", true);

				aiLook.enabled = false;

				currentAiLocation = "Kitchen";
			}
			else if (currentAiLocation == "TV"){
				iTweenEvent.GetEvent(Player,"TvToKitchen").Play();

				iTweenEvent.GetEvent(AI,"TvToKitchenEvent").Play();

				aiLook.enabled = false;
				anim.SetBool("isWalking", true);



				currentAiLocation = "Kitchen";
			}
			else if (currentAiLocation == "Kitchen"){
				//Do nothing since you're already there
			}

			//iTweenEvent.GetEvent(AI,"KitchenPathEvent").Play();
			//aiLook.enabled = false;
			//anim.SetBool("isWalking", true);

			choiceCounter++;
			LeaveDialog();
		break;	
		
		case 3:
			print ("case3 ACTIVATE!");

			StartCoroutine("ThreatenAudio");

			choiceCounter++;
			LeaveDialog();
			break;
		
		case 4:
			print ("case4 ACTIVATE!");

			StartCoroutine("IgnoreAudio");

			choiceCounter++;
			LeaveDialog();
			break;

		case 5:
			print ("case5 ACTIVATE!");

			StartCoroutine("LeaveAudio");

			choiceCounter++;
			LeaveDialog();
			break;
			
		case 6:
			print ("case6 ACTIVATE!");

			StartCoroutine("JokeAudio");

			choiceCounter++;
			LeaveDialog();
			break;	
			
		case 7:
			print ("case7 ACTIVATE!");

			StartCoroutine("InsultAudio");

			choiceCounter++;
			LeaveDialog();
			break;
			
		case 8:
			print ("case8 ACTIVATE!");

			StartCoroutine("TalkItOutAudio");

			choiceCounter++;
			LeaveDialog();
			break;

		case 9:
			print ("case9 ACTIVATE!");

			iTweenEvent.GetEvent(Player,"ReportIt").Play();
			
			StartCoroutine("ReportItAudio");

			choiceCounter++;
			LeaveDialog();
			break;

		default:
			break;
		}
	}
	
	void AddToFile(){
		//StreamWriter sw = new StreamWriter("TestFile.txt");
		StreamWriter sw = File.AppendText ("TestFile.txt");
		sw.Write (",");
		sw.Write (choiceCounter);
		sw.Close ();
	}

	public IEnumerator CutInLine (){

		yield return new WaitForSeconds(2.5f);
		anim.SetBool("isWalking", true);
		iTweenEvent.GetEvent(AI,"CutInLine").Play();
	}

	public IEnumerator ReportItAudio (){
		
		yield return new WaitForSeconds(2.0f);

		audio.clip = audioReportIt.clip1;
		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);
		
		audio.clip = audioReportIt.clip2;
		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);
		iTweenEvent.GetEvent(Manager,"ManagerReportIt").Play();

		aiLook.enabled = true;

		yield return new WaitForSeconds (4.0f);

		audio.clip = audioReportIt.clip3;
		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);
		
		audio.clip = audioReportIt.clip4;
		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);

		audio.clip = audioReportIt.clip5;
		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);
		iTweenEvent.GetEvent(Manager,"ManagerLeave").Play();

		state.itemUseable = false;
	}

	public IEnumerator TalkItOutAudio (){

		audio.clip = audioTalkItOut.clip1;
		audio.Play ();
		yield return new WaitForSeconds(audio.clip.length);
		
		audio.clip = audioTalkItOut.clip2;
		audio.Play ();
		
		yield return new WaitForSeconds(audio.clip.length);

		state.itemUseable = false;
	}
	
	public IEnumerator InsultAudio (){

		audio.clip = audioInsult.clip1;
		audio.Play ();
		yield return new WaitForSeconds(audio.clip.length);
		
		audio.clip = audioInsult.clip2;
		audio.Play ();
		
		yield return new WaitForSeconds(audio.clip.length);
		
		state.itemUseable = false;
	}
		
	public IEnumerator JokeAudio (){
		
		audio.clip = audioJoke.clip1;
		audio.Play ();
		yield return new WaitForSeconds(audio.clip.length);
		
		audio.clip = audioJoke.clip2;
		audio.Play ();
		
		yield return new WaitForSeconds(audio.clip.length);
		
		state.itemUseable = false;
	}

	public IEnumerator ThreatenAudio (){
		
		audio.clip = audioThreaten.clip1;
		audio.Play ();
		yield return new WaitForSeconds(audio.clip.length);
		
		audio.clip = audioThreaten.clip2;
		audio.Play ();
		
		yield return new WaitForSeconds(audio.clip.length);
		
		state.itemUseable = false;
	}

	public IEnumerator IgnoreAudio (){
		
		audio.clip = audioIgnore.clip1;
		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);
		
		state.itemUseable = false;
	}

	public IEnumerator LeaveAudio (){
		
		audio.clip = audioLeave.clip1;
		audio.Play ();
		
		yield return new WaitForSeconds(audio.clip.length);
		
		state.itemUseable = false;
	}



	void LeaveDialog(){
		state.itemUseable = true;
		
		//GameObject.FindWithTag("Description").GetComponent<GUIText>().text = "";
		//GameObject.FindWithTag("Description").GetComponent<GUIText>().enabled = false;
		
		GameObject.FindWithTag("PlayerArms").GetComponent<Animation>().enabled = true;

		AddToFile();

		print("Exited Dialog!");
	}



	void eventEnd(){
		
		if (choiceCounter == maxChoiceNum){
			iTween.CameraFadeAdd ();
			iTween.CameraFadeFrom (1,1);
			//Application.Quit();
			Application.LoadLevel ("Menu"); 
		}
		
		anim.SetBool("isWalking", false);
		state.itemUseable = false;
		//Uncomment to let the AI look at you when he's done walking
		//aiLook.enabled = true;
	}
}

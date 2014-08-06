using System.IO;
using System;

using UnityEngine;
using System.Collections;

[System.Serializable]
public class audio_Scene04_ReportIt {
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;
	public AudioClip clip4;
}

[System.Serializable]
public class audio_Scene04_TalkItOut {
	public AudioClip clip1;
	public AudioClip clip2;
}

[System.Serializable]
public class audio_Scene04_Insult {
	public AudioClip clip1;
	public AudioClip clip2;
}

[System.Serializable]
public class audio_Scene04_Joke {
	public AudioClip clip1;
	public AudioClip clip2;
}

[System.Serializable]
public class audio_Scene04_Threaten {
	public AudioClip clip1;
	public AudioClip clip2;
}

public class CharacterResponses_Scene_04 : MonoBehaviour {
	public CharacterInteract_Scene_04 state;
	public FocusOnPlayer aiLook;
	public GameObject AI;
	public DialogGUI_Scene_04 dialogue;
	//public Transform targetLook;

	private Animator anim;
	private Animator animTV;
	private Animator animKitchen;
	public GameObject Player;

	public audio_Scene04_ReportIt audioReportIt;
	public audio_Scene04_TalkItOut audioTalkItOut;
	public audio_Scene04_Insult audioInsult;
	public audio_Scene04_Joke audioJoke;
	public audio_Scene04_Threaten audioThreaten;

	int choiceCounter;
	bool isSitting;
	string currentAiLocation;
	int maxChoiceNum;
	float delay;

	void Start() {
		anim = GetComponent<Animator>();
		//animTV = GameObject.Find("TVOn_0").GetComponent<Animator>();
		currentAiLocation = "default";
		maxChoiceNum = 2;
		//Player = GameObject.Find("FirstPersonController");
	}

	void Update(){

		if (choiceCounter == maxChoiceNum){
			iTween.CameraFadeAdd ();
			iTween.CameraFadeFrom (1,1);
			//Application.Quit();
			Application.LoadLevel ("Menu"); 
		}

		isSitting = anim.GetBool("isSitting");
		print ("isSitting = " + isSitting);
		print ("ChoiceCounter = " + choiceCounter);
		print ("Current Location = " + currentAiLocation);

	}

	public void checkResponse(int caseNum){
		switch(caseNum){

		case 1:
			print ("Report It ACTIVATE!");
			//GameObject.Find("radial_background").GetComponent<MeshRenderer>().enabled = false;
			//GameObject.Find ("radial_background").GetComponentInChildren<MeshRenderer>().enabled = false;
			//May want to use case inside case statement
			LeaveDialog();
			StartCoroutine("ReportItAudio");
	
			choiceCounter++;
			//LeaveDialog();

			break;
		
		case 2:
			print ("case2 ACTIVATE!");

			LeaveDialog();
			StartCoroutine("TalkItOutAudio");

			choiceCounter++;
		break;	
		
		case 3:
			print ("Threaten ACTIVATE!");

			StartCoroutine("ThreatenAudio");

			choiceCounter++;
			LeaveDialog();
			break;
		
		case 4:
			print ("Ignore ACTIVATE!");

			if (currentAiLocation == "default"){
				
				iTweenEvent.GetEvent(Player,"SideStepEvent").Play();
				anim.SetBool("isWalking", true);
				iTweenEvent.GetEvent(AI,"WalkToGroupEvent").Play();
				currentAiLocation = "TV";
			}
			else if (currentAiLocation == "TV"){
				//Do nothing
			}


			choiceCounter++;
			LeaveDialog();
			break;

		case 5:
			print ("Leave ACTIVATE!");

			if (currentAiLocation == "default"){
				
				iTweenEvent.GetEvent(Player,"SideStepEvent").Play();
				anim.SetBool("isWalking", true);
				iTweenEvent.GetEvent(AI,"WalkToGroupEvent").Play();
				currentAiLocation = "TV";
			}
			else if (currentAiLocation == "TV"){
				//Do nothing
			}


			choiceCounter++;
			LeaveDialog();
			break;
			
		case 6:
			print ("Joke ACTIVATE!");

			
			LeaveDialog();
			StartCoroutine("JokeAudio");
			
			choiceCounter++;
			break;	
			
		case 7:
			print ("Insult ACTIVATE!");

			LeaveDialog();
			StartCoroutine("InsultAudio");

			choiceCounter++;
			break;
			
		case 8:
			print ("Talk It Out ACTIVATE!");

			LeaveDialog();
			StartCoroutine("TalkItOutAudio");

			choiceCounter++;
			break;

		case 9:
			print ("Report It ACTIVATE!");

			LeaveDialog();
			StartCoroutine("ReportItAudio");

			choiceCounter++;
			break;

		default:
			break;
		}
	}

	public IEnumerator ReportItAudio (){

		audio.clip = audioReportIt.clip1;
		audio.Play ();
		yield return new WaitForSeconds(audio.clip.length);
		
		audio.clip = audioReportIt.clip2;
		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);
		
		audio.clip = audioReportIt.clip3;
		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);
		
		audio.clip = audioReportIt.clip4;
		audio.Play ();
		yield return new WaitForSeconds(audio.clip.length);
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

	void AddToFile(){
		//StreamWriter sw = new StreamWriter("TestFile.txt");
		/*StreamWriter sw = File.AppendText ("TestFile.txt");
		sw.Write (",");
		sw.Write (choiceCounter);
		sw.Close ();*/
	}

	void LeaveDialog(){
		state.itemUseable = true;
		
		//GameObject.FindWithTag("Description").GetComponent<GUIText>().text = "";
		//GameObject.FindWithTag("Description").GetComponent<GUIText>().enabled = false;
		
		GameObject.FindWithTag("PlayerArms").GetComponent<Animation>().enabled = true;

		AddToFile();

		print("Exited Dialog!");
	}

	void tvEventEnd(){

		anim.SetBool("isWalking", false);
		eventEnd ();
		//anim.SetBool("interact", true);
		/*if(anim.GetFloat("interactTime") == 0.12){
			animTV.SetBool("isTVOn", true);
			anim.SetBool("interact", false);
		}*/
		animTV.SetBool("isTVOn", true);
		iTweenEvent.GetEvent(AI,"SitEvent").Play();
		anim.SetBool("isWalking", true);
	}

	void kitchenEventEnd(){

		anim.SetBool("interact", true);
		eventEnd ();
	}

	void chairEventEnd(){

		//transform.LookAt(new Vector3(targetLook.position.x, transform.position.y, targetLook.position.z));
	
		anim.SetBool("isSitting", true);
		eventEnd ();
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

using System.IO;
using System;

using UnityEngine;
using System.Collections;

public class CharacterResponses_Scene_05 : MonoBehaviour {
	public CharacterInteract_Scene_05 state;
	public FocusOnPlayer aiLook;
	public GameObject AI;
	public DialogGUI_Scene_05 dialogue;
	//public Transform targetLook;

	private Animator anim;
	private Animator animTV;
	private Animator animKitchen;
	public GameObject Player;

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
			//May want to use case inside case statement

			iTweenEvent.GetEvent(Player,"SideStepEvent").Play();
			anim.SetBool("isWalking", true);
			iTweenEvent.GetEvent(AI,"WalkToGroupEvent").Play();
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

			choiceCounter++;
			LeaveDialog();
			break;
		
		case 4:
			print ("case4 ACTIVATE!");

			choiceCounter++;
			LeaveDialog();
			break;

		case 5:
			print ("case5 ACTIVATE!");

			choiceCounter++;
			LeaveDialog();
			break;
			
		case 6:
			print ("case6 ACTIVATE!");

			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);

			choiceCounter++;
			LeaveDialog();
			break;	
			
		case 7:
			print ("case7 ACTIVATE!");

			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);

			choiceCounter++;
			LeaveDialog();
			break;
			
		case 8:
			print ("case8 ACTIVATE!");

			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);

			choiceCounter++;
			LeaveDialog();
			break;

		case 9:
			print ("case9 ACTIVATE!");

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

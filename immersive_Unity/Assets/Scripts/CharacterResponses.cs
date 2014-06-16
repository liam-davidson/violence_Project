using System.IO;
using System;

using UnityEngine;
using System.Collections;

public class CharacterResponses : MonoBehaviour {
	public CharacterInteract state;
	public FocusOnPlayer aiLook;
	public GameObject AI;
	public DialogGUI dialogue;

	private Animator anim;
		
	int choiceCounter;

	void Start() {
		anim = GetComponent<Animator>();
	}

	void Update(){

		print ("ChoiceCounter = " + choiceCounter);
	}

	public void checkResponse(int caseNum){
		switch(caseNum){
		
		case 1:
			print ("case1 ACTIVATE!");

			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);

			choiceCounter++;
			LeaveDialog();
			break;
		
		case 2:
			print ("case2 ACTIVATE!");

			iTweenEvent.GetEvent(AI,"KitchenPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);

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

		StreamWriter sw = File.AppendText ("TestFile.xml");

		sw.WriteLine ("<?xml version='1.0' encoding='UTF-8'?>");
		sw.Write ("<Scene>");

		sw.WriteLine ("\t<Choice>");
		sw.WriteLine ("\t\t" + dialogue.responseNum);
		sw.WriteLine ("\t</Choice>");

		sw.WriteLine ("</Scene>");
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

	void eventEnd(){

		if (choiceCounter == 2){
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

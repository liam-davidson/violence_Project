using System.IO;
using System;

using UnityEngine;
using System.Collections;

public class CharacterResponses : MonoBehaviour {
	public CharacterInteract state;

	public FocusOnPlayer aiLook;

	public GameObject AI;

	private Animator anim;

	public DialogGUI dialogue;

	public Transform[] waypoints;

	void Start() {
		anim = GetComponent<Animator>();
		}

	public void checkResponse(int caseNum){
		switch(caseNum){
		
		case 1:
			print ("case1 ACTIVATE!");
			//splineMover.startMove();
			//waypointMove.currentWaypoint = waypoints[0];
			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);
			LeaveDialog();
			break;
		
		case 2:
			print ("case2 ACTIVATE!");
			iTweenEvent.GetEvent(AI,"KitchenPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);
			LeaveDialog();
		break;	
		
		case 3:
			print ("case3 ACTIVATE!");
			LeaveDialog();
			break;
		
		case 4:
			print ("case4 ACTIVATE!");
			LeaveDialog();
			break;

		case 5:
			print ("case5 ACTIVATE!");
			LeaveDialog();
			break;
			
		case 6:
			print ("case6 ACTIVATE!");
			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);
			LeaveDialog();
			break;	
			
		case 7:
			print ("case7 ACTIVATE!");
			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);
			break;
			
		case 8:
			print ("case8 ACTIVATE!");
			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			anim.SetBool("isWalking", true);
			LeaveDialog();
			break;

		case 9:
			print ("case9 ACTIVATE!");
			LeaveDialog();

			break;

		default:
			break;
		}
	}

	/*
	void WriteToFile(){

		// Create an instance of StreamWriter to write text to a file.
		StreamWriter sw = new StreamWriter("TestFile.txt");
		// Add some text to the file.
		sw.Write("This is the ");
		sw.WriteLine("header for the file.");
		sw.WriteLine("-------------------");
		// Arbitrary objects can also be written to the file.
		sw.Write("The date is: ");
		sw.WriteLine(DateTime.Now);
		sw.WriteLine("-------------------");
		sw.WriteLine(dialogue.responseNum);
		sw.WriteLine("-------------------");
		sw.Close();
	}
	*/

	void AddToFile(){
		//StreamWriter sw = new StreamWriter("TestFile.txt");
		StreamWriter sw = File.AppendText ("TestFile.xml");
		//sw.Write ("This line was appended.");
		//sw.WriteLine ("This one too.");
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
		
		GameObject.FindWithTag("Description").GetComponent<GUIText>().text = "";
		GameObject.FindWithTag("Description").GetComponent<GUIText>().enabled = false;
		
		GameObject.FindWithTag("PlayerArms").GetComponent<Animation>().enabled = true;

		//WriteToFile();
		AddToFile();

		print("Exited Dialog!");
	}

	void eventEnd(){
		anim.SetBool("isWalking", false);
		aiLook.enabled = true;
	}
}

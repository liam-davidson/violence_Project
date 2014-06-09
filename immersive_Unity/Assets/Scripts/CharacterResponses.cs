using UnityEngine;
using System.Collections;

public class CharacterResponses : MonoBehaviour {
	public CharacterInteract state;

	public FocusOnPlayer aiLook;

	public GameObject AI;
	
	public Transform[] waypoints;

	public void checkResponse(int caseNum){
		switch(caseNum){
		
		case 1:
			print ("case1 ACTIVATE!");
			//splineMover.startMove();
			//waypointMove.currentWaypoint = waypoints[0];
			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			LeaveDialog();
			break;
		
		case 2:
			print ("case2 ACTIVATE!");
			iTweenEvent.GetEvent(AI,"KitchenPathEvent").Play();
			aiLook.enabled = false;
			LeaveDialog();
		break;	
		
		case 3:
			print ("case3 ACTIVATE!");
			break;
		
		case 4:
			print ("case4 ACTIVATE!");
			break;

		case 5:
			print ("case5 ACTIVATE!");
			break;
			
		case 6:
			print ("case6 ACTIVATE!");
			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			break;	
			
		case 7:
			print ("case7 ACTIVATE!");
			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			break;
			
		case 8:
			print ("case8 ACTIVATE!");
			iTweenEvent.GetEvent(AI,"TVPathEvent").Play();
			aiLook.enabled = false;
			break;

		case 9:
			print ("case9 ACTIVATE!");
			LeaveDialog();

			break;

		default:
			break;
		}
	}

	void LeaveDialog(){
		state.itemUseable = true;
		
		GameObject.FindWithTag("Description").GetComponent<GUIText>().text = "";
		GameObject.FindWithTag("Description").GetComponent<GUIText>().enabled = false;
		
		GameObject.FindWithTag("PlayerArms").GetComponent<Animation>().enabled = true;
		
		print("Exited Dialog!");
	}

	void LookAtPlayer(){
		aiLook.enabled = true;
	}

}

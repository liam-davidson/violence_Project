using UnityEngine;
using System.Collections;

public class CharacterResponses : MonoBehaviour {
	public CharacterInteract state;
	public MoveToWaypoint waypointMove;
	public UniformBSplineMover splineMover;
	public FocusOnPlayer aiLook;

	public GameObject AI;
	
	public Transform[] waypoints;

	public void checkResponse(int caseNum){
		switch(caseNum){
		
		case 1:
			print ("case1 ACTIVATE!");
			//splineMover.startMove();
			//waypointMove.currentWaypoint = waypoints[0];
			iTween.MoveTo(AI,iTween.Hash("x", 0.1, "easeType", "easeInOutExpo", "delay", 0.75, "time", 2, "orienttopath", true));
			//aiLook.enabled = false;
			LeaveDialog();
			break;
		
		case 2:
			print ("case2 ACTIVATE!");
			//waypointMove.enabled = true;
			//waypointMove.changeWaypoint("Waypoint2");
			//waypointMove.currentWaypoint = waypoints[1];
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
			break;	
			
		case 7:
			print ("case7 ACTIVATE!");
			break;
			
		case 8:
			print ("case8 ACTIVATE!");
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

}

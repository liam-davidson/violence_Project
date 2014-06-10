using UnityEngine;
using System.Collections;

[System.Serializable]
public class options
{
	public string option1;
	public string option2;
	public string option3;
	public string option4;
	public string option5;
	public string option6;
	public string option7;
	public string option8;
	public string option9;
}

public class DialogGUI : MonoBehaviour {
	
	private CharacterInteract state;
	private Vector3 scale;

	public options dialogMenu;
	public CharacterResponses response;
	public Vector3 lookTarget;
	
	float originalWidth = 1024.0f;
	float originalHeight = 768.0f;
	float traverseSpeed = 360;

	public int responseNum;

	void Start(){
		state = gameObject.GetComponent<CharacterInteract>();
		responseNum = 0;
	}
	
	void OnGUI(){

		scale.x = Screen.width / originalWidth;
		scale.y = Screen.height / originalHeight;
		scale.z = 1;

		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, scale);

		var guiMat = GUI.matrix;

		var halfWidth = Screen.width/2;

		var buttonWidth = 150;
		var buttonHeight = 50;

		float groupWidth = 580.0f;
		float groupHeight = 280.0f;

		//*****************************************
		//TODO change if statements to Statemachine
		//*****************************************

		GUIStyle guiSpacing = new GUIStyle (GUI.skin.button);
		guiSpacing.padding.bottom = 10;
		guiSpacing.padding.top = 10;

		GUI.BeginGroup (new Rect (halfWidth - groupWidth/2, Screen.height - groupHeight, groupWidth, groupHeight));

		GUI.Box (new Rect (0,0,580,280),"");
		#region Button Options
		//TODO remove magic number button position
		//replace with positionH + 10


		//TODO refrence other script in if statements, pass a var to them who's value will be
		//used as the switch for a case statement. These cases will contain the Ai reactions.
		if (GUI.Button (new Rect (50, 40, buttonWidth, buttonHeight), dialogMenu.option1, guiSpacing)) {
			
			print("Button Clicked!");
			changeDescription("test");
			responseNum = 1;
			response.checkResponse(responseNum);
		}

		if (GUI.Button (new Rect (370, 40, buttonWidth, buttonHeight), dialogMenu.option2, guiSpacing)) {
			
			print("Button Clicked!");
			changeDescription("test2");
			responseNum = 2;
			response.checkResponse(responseNum);
		}
		if (GUI.Button (new Rect (10, 100, buttonWidth, buttonHeight), dialogMenu.option3)) {
			
			print("Button Clicked!");
			changeDescription("test3");
			responseNum = 3;
			response.checkResponse(responseNum);
		}
		
		if (GUI.Button (new Rect (10, 160, buttonWidth, buttonHeight), dialogMenu.option4)) {
			
			print("Button Clicked!");
			changeDescription("test4");	
			responseNum = 4;
			response.checkResponse(responseNum);
		}

		if (GUI.Button (new Rect (420, 100, buttonWidth, buttonHeight), dialogMenu.option5)) {
			
			print("Button Clicked!");
			changeDescription("test5");
			responseNum = 5;
			response.checkResponse(responseNum);
		}
		
		if (GUI.Button (new Rect (420, 160, buttonWidth, buttonHeight), dialogMenu.option6)) {
			
			print("Button Clicked!");
			changeDescription("test6");
			responseNum = 6;
			response.checkResponse(responseNum);
		}

		if (GUI.Button (new Rect (50, 220, buttonWidth, buttonHeight), dialogMenu.option7)) {
			
			print("Button Clicked!");
			changeDescription("test7");
			responseNum = 7;
			response.checkResponse(responseNum);
		}
		if (GUI.Button (new Rect (210, 220, buttonWidth, buttonHeight), dialogMenu.option8)) {
			
			print("Button Clicked!");
			changeDescription("test8");
			responseNum = 8;
			response.checkResponse(responseNum);
		}
		if (GUI.Button (new Rect (370, 220, buttonWidth, buttonHeight), dialogMenu.option9)) {
			
			print("Button Clicked!");
			changeDescription("test9");
			responseNum = 9;
			response.checkResponse(responseNum);
		}
		#endregion
		GUI.EndGroup ();

		//if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetButton("Exit"))) {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			state.itemUseable = true;
			GameObject.FindWithTag("Description").GetComponent<GUIText>().text = "";
			GameObject.FindWithTag("Description").GetComponent<GUIText>().enabled = false;

			GameObject.FindWithTag("PlayerArms").GetComponent<Animation>().enabled = true;

			print("Exited Dialog!");

		}
		GUI.matrix = guiMat;

	}

	void changeDescription (string description){

		GameObject.FindWithTag("Description").GetComponent<GUIText>().text = description;
	}
}

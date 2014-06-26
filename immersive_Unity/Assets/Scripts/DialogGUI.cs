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

	public GameObject controllerArrow;
	public GameObject Option1;
	public GameObject Option2;
	public GameObject Option3;
	public GameObject Option4;
	public GameObject Option5;
	public GameObject Option6;
	public GameObject Option7;
	public GameObject Option8;
	public GameObject Option9;

	public Material off_1;
	public Material off_2;
	public Material off_3;
	public Material off_4;
	public Material off_5;
	public Material off_6;
	public Material off_7;
	public Material off_8;
	public Material off_9;

	public float y;
	public float x;
	
	public Vector2 centerVector;
	public Vector2 stickVector;
	public Vector3 v3;

	public string text;
	public float angle;
	
	public float test;
	public float deltaX;
	public float deltaY;

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

	void Update () {
		x = Input.GetAxis("JoyHorizontal");
		y = Input.GetAxis("JoyVertical");
		
		stickVector.x = x;
		stickVector.y = y;

		centerVector.x = 0.0f;
		centerVector.y = 0.0f;
		
		angle = Vector2.Angle(stickVector, centerVector);
		
		deltaX = x - 0;
		deltaY = y - 0;
		
		test = Mathf.Atan2(deltaY, deltaX) * 180 / 3.14f;

		v3.x = -test;
		v3.y = 90;
		v3.z = -90;

		controllerArrow.transform.localEulerAngles = v3;

		//Debug.Log (test);

		Option1.renderer.material = off_1;
		Option2.renderer.material = off_2;
		Option3.renderer.material = off_3;
		Option4.renderer.material = off_4;
		Option5.renderer.material = off_5;
		Option6.renderer.material = off_6;
		Option7.renderer.material = off_7;
		Option8.renderer.material = off_8;
		Option9.renderer.material = off_9;

		if (test < 72 && test > 36) {
			//Option1.renderer.enabled = false;
			Option1.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				changeDescription("test");
				responseNum = 1;
				response.checkResponse(responseNum);
			}
		}
		if (test < 36 && test > 0) {
			Option2.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				changeDescription("test2");
				responseNum = 2;
				response.checkResponse(responseNum);
			}
		}
		if (test < 0 && test > -36) {
			Option3.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				changeDescription("test3");
				responseNum = 3;
				response.checkResponse(responseNum);
			}
		}
		if (test < -36 && test > -72) {
			Option4.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				changeDescription("test4");
				responseNum = 4;
				response.checkResponse(responseNum);
			}
		}
		if (test < -72 && test > -108) {
			Option5.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				changeDescription("test5");
				responseNum = 5;
				response.checkResponse(responseNum);
			}
		}
		if (test < -108 && test > -138) {
			Option6.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				changeDescription("test6");
				responseNum = 6;
				response.checkResponse(responseNum);
			}
		}
		if (test < -144 && test > -179) {
			Option7.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				changeDescription("test7");
				responseNum = 7;
				response.checkResponse(responseNum);
			}
		}
		if (test < 179 && test > 144) {
			Option8.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				changeDescription("test8");
				responseNum = 8;
				response.checkResponse(responseNum);
			}
		}
		if (test < 144 && test > 108) {
			Option9.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				changeDescription("test9");
				responseNum = 9;
				response.checkResponse(responseNum);
			}
		}
	}

	/*
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
	*/

	void changeDescription (string description){

		//GameObject.FindWithTag("Description").GetComponent<GUIText>().text = description;
	}
}

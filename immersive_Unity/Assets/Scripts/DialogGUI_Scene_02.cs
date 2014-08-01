using UnityEngine;
using System.Collections;

public class DialogGUI_Scene_02 : MonoBehaviour {
	
	private float y;
	private float x;
	
	private Vector2 centerVector;
	private Vector2 stickVector;
	private Vector3 v3;
	
	private string text;
	private float angle;
	
	private float test;
	private float deltaX;
	private float deltaY;

	private CharacterInteract_Scene_02 state;
	private Vector3 scale;
	private CharacterResponses_Scene_02 response;
	
	float originalWidth = 1024.0f;
	float originalHeight = 768.0f;
	float traverseSpeed = 360;

	GameObject radialBackground;
	GameObject controllerArrow;
	GameObject Option1;
	GameObject Option2;
	GameObject Option3;
	GameObject Option4;
	GameObject Option5;
	GameObject Option6;
	GameObject Option7;
	GameObject Option8;
	GameObject Option9;

	Material off_1;
	Material off_2;
	Material off_3;
	Material off_4;
	Material off_5;
	Material off_6;
	Material off_7;
	Material off_8;
	Material off_9;

	public int responseNum;

	void Start(){
		state = gameObject.GetComponent<CharacterInteract_Scene_02>();
		response = GetComponent<CharacterResponses_Scene_02>();
		responseNum = 0;


		radialBackground = GameObject.Find("radial_background");
		controllerArrow = GameObject.Find("radial_dial");
		Option1 = GameObject.Find("radial_1");
		Option2 = GameObject.Find("radial_2");
		Option3 = GameObject.Find("radial_3");
		Option4 = GameObject.Find("radial_4");
		Option5 = GameObject.Find("radial_5");
		Option6 = GameObject.Find("radial_6");
		Option7 = GameObject.Find("radial_7");
		Option8 = GameObject.Find("radial_8");
		Option9 = GameObject.Find("radial_9");

		off_1 = Resources.Load("radial_material_1", typeof(Material)) as Material;
		off_2 = Resources.Load("radial_material_2", typeof(Material)) as Material;
		off_3 = Resources.Load("radial_material_3", typeof(Material)) as Material;
		off_4 = Resources.Load("radial_material_4", typeof(Material)) as Material;
		off_5 = Resources.Load("radial_material_5", typeof(Material)) as Material;
		off_6 = Resources.Load("radial_material_6", typeof(Material)) as Material;
		off_7 = Resources.Load("radial_material_7", typeof(Material)) as Material;
		off_8 = Resources.Load("radial_material_8", typeof(Material)) as Material;
		off_9 = Resources.Load("radial_material_9", typeof(Material)) as Material;


		controllerArrow.renderer.enabled = true;
		radialBackground.renderer.enabled = true;
		Option1.renderer.enabled = true;
		Option2.renderer.enabled = true;
		Option3.renderer.enabled = true;
		Option4.renderer.enabled = true;
		Option5.renderer.enabled = true;
		Option6.renderer.enabled = true;
		Option7.renderer.enabled = true;
		Option8.renderer.enabled = true;
		Option9.renderer.enabled = true;

	}

	void Update () {
		x = Input.GetAxis("JoyHorizontal");
		y = Input.GetAxis("JoyVertical");

		//x = Input.mousePosition.x;
		//y = Input.mousePosition.y;

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
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test");
				responseNum = 1;
				response.checkResponse(responseNum);
			}
		}
		if (test < 36 && test > 0) {
			Option2.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test2");
				responseNum = 2;
				response.checkResponse(responseNum);
			}
		}
		if (test < 0 && test > -36) {
			Option3.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test3");
				responseNum = 3;
				response.checkResponse(responseNum);
			}
		}
		if (test < -36 && test > -72) {
			Option4.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test4");
				responseNum = 4;
				response.checkResponse(responseNum);
			}
		}
		if (test < -72 && test > -108) {
			Option5.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test5");
				responseNum = 5;
				response.checkResponse(responseNum);
			}
		}
		if (test < -108 && test > -138) {
			Option6.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test6");
				responseNum = 6;
				response.checkResponse(responseNum);
			}
		}
		if (test < -144 && test > -179) {
			Option7.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test7");
				responseNum = 7;
				response.checkResponse(responseNum);
			}
		}
		if (test < 179 && test > 144) {
			Option8.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test8");
				responseNum = 8;
				response.checkResponse(responseNum);
			}
		}
		if (test < 144 && test > 108) {
			Option9.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test9");
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

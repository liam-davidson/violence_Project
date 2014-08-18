using UnityEngine;
using System.Collections;


public class DialogGUI_Scene_01 : MonoBehaviour {
	
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
	
	private CharacterInteract_Scene_01 state;
	private Vector3 scale;
	private CharacterResponses response;
	
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
		state = gameObject.GetComponent<CharacterInteract_Scene_01>();
		response = GetComponent<CharacterResponses>();
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
		
		
		controllerArrow.renderer.enabled = false;
		radialBackground.renderer.enabled = false;
		Option1.renderer.enabled = false;
		Option2.renderer.enabled = false;
		Option3.renderer.enabled = false;
		Option4.renderer.enabled = false;
		Option5.renderer.enabled = false;
		Option6.renderer.enabled = false;
		Option7.renderer.enabled = false;
		Option8.renderer.enabled = false;
		Option9.renderer.enabled = false;
		
		
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
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				//if (Input.GetMouseButton(0)){
				//changeDescription("test");
				responseNum = 1;
				response.checkResponse(responseNum);
			}
		}
		if (test < 36 && test > 0) {
			Option2.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				//if (Input.GetMouseButton(0)){
				//changeDescription("test2");
				responseNum = 2;
				response.checkResponse(responseNum);
			}
		}
		if (test < 0 && test > -36) {
			Option3.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				//if (Input.GetMouseButton(0)){
				//changeDescription("test3");
				responseNum = 3;
				response.checkResponse(responseNum);
			}
		}
		if (test < -36 && test > -72) {
			Option4.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				//if (Input.GetMouseButton(0)){
				//changeDescription("test4");
				responseNum = 4;
				response.checkResponse(responseNum);
			}
		}
		if (test < -72 && test > -108) {
			Option5.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				//if (Input.GetMouseButton(0)){
				//changeDescription("test5");
				responseNum = 5;
				response.checkResponse(responseNum);
			}
		}
		if (test < -108 && test > -138) {
			Option6.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				//if (Input.GetMouseButton(0)){
				//changeDescription("test6");
				responseNum = 6;
				response.checkResponse(responseNum);
			}
		}
		if (test < -144 && test > -179) {
			Option7.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				//if (Input.GetMouseButton(0)){
				//changeDescription("test7");
				responseNum = 7;
				response.checkResponse(responseNum);
			}
		}
		if (test < 179 && test > 144) {
			Option8.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				//if (Input.GetMouseButton(0)){
				//changeDescription("test8");
				responseNum = 8;
				response.checkResponse(responseNum);
			}
		}
		if (test < 144 && test > 108) {
			Option9.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.JoystickButton0)){
				//if (Input.GetMouseButton(0)){
				//changeDescription("test9");
				responseNum = 9;
				response.checkResponse(responseNum);
			}
		}
	}
}


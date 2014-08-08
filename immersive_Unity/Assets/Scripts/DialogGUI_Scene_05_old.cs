using UnityEngine;
using System.Collections;

[System.Serializable]
public class options_S05 {
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
[System.Serializable]
public class radialMenu_S05 {
	public GameObject radialBackground;
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

}
[System.Serializable]
public class radialMat_S05 {
	public Material off_1;
	public Material off_2;
	public Material off_3;
	public Material off_4;
	public Material off_5;
	public Material off_6;
	public Material off_7;
	public Material off_8;
	public Material off_9;
	
}

public class DialogGUI_Scene_05_old : MonoBehaviour {
	
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

	private CharacterInteract_Scene_05 state;
	private Vector3 scale;
	private CharacterResponses_Scene_05 response;

	public options_S05 dialogMenu;
	public radialMenu_S05 radialMenuObj;
	public radialMat_S05 radialMenuMat;

		
	float originalWidth = 1024.0f;
	float originalHeight = 768.0f;
	float traverseSpeed = 360;

	public int responseNum;

	void Start(){
		state = gameObject.GetComponent<CharacterInteract_Scene_05>();
		response = GetComponent<CharacterResponses_Scene_05>();
		responseNum = 0;

		radialMenuObj.controllerArrow.renderer.enabled = false;
		radialMenuObj.radialBackground.renderer.enabled = false;
		radialMenuObj.Option1.renderer.enabled = false;
		radialMenuObj.Option2.renderer.enabled = false;
		radialMenuObj.Option3.renderer.enabled = false;
		radialMenuObj.Option4.renderer.enabled = false;
		radialMenuObj.Option5.renderer.enabled = false;
		radialMenuObj.Option6.renderer.enabled = false;
		radialMenuObj.Option7.renderer.enabled = false;
		radialMenuObj.Option8.renderer.enabled = false;
		radialMenuObj.Option9.renderer.enabled = false;
	
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

		radialMenuObj.controllerArrow.transform.localEulerAngles = v3;

		radialMenuObj.Option1.renderer.material = radialMenuMat.off_1;
		radialMenuObj.Option2.renderer.material = radialMenuMat.off_2;
		radialMenuObj.Option3.renderer.material = radialMenuMat.off_3;
		radialMenuObj.Option4.renderer.material = radialMenuMat.off_4;
		radialMenuObj.Option5.renderer.material = radialMenuMat.off_5;
		radialMenuObj.Option6.renderer.material = radialMenuMat.off_6;
		radialMenuObj.Option7.renderer.material = radialMenuMat.off_7;
		radialMenuObj.Option8.renderer.material = radialMenuMat.off_8;
		radialMenuObj.Option9.renderer.material = radialMenuMat.off_9;

		if (test < 72 && test > 36) {
			//Option1.renderer.enabled = false;
			radialMenuObj.Option1.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test");
				responseNum = 1;
				response.checkResponse(responseNum);
			}
		}
		if (test < 36 && test > 0) {
			radialMenuObj.Option2.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test2");
				responseNum = 2;
				response.checkResponse(responseNum);
			}
		}
		if (test < 0 && test > -36) {
			radialMenuObj.Option3.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test3");
				responseNum = 3;
				response.checkResponse(responseNum);
			}
		}
		if (test < -36 && test > -72) {
			radialMenuObj.Option4.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test4");
				responseNum = 4;
				response.checkResponse(responseNum);
			}
		}
		if (test < -72 && test > -108) {
			radialMenuObj.Option5.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test5");
				responseNum = 5;
				response.checkResponse(responseNum);
			}
		}
		if (test < -108 && test > -138) {
			radialMenuObj.Option6.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test6");
				responseNum = 6;
				response.checkResponse(responseNum);
			}
		}
		if (test < -144 && test > -179) {
			radialMenuObj.Option7.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test7");
				responseNum = 7;
				response.checkResponse(responseNum);
			}
		}
		if (test < 179 && test > 144) {
			radialMenuObj.Option8.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test8");
				responseNum = 8;
				response.checkResponse(responseNum);
			}
		}
		if (test < 144 && test > 108) {
			radialMenuObj.Option9.renderer.material.color = Color.red;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
			//if (Input.GetMouseButton(0)){
				//changeDescription("test9");
				responseNum = 9;
				response.checkResponse(responseNum);
			}
		}
	}
	
	void changeDescription (string description){

		//GameObject.FindWithTag("Description").GetComponent<GUIText>().text = description;
	}
}

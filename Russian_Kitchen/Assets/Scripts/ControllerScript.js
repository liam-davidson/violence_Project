#pragma strict

var x : float;
var y : float;
var centerVector : Vector2;
var stickVector : Vector2;
var text : String;
var angle : float;

var test : float;
var deltaX : float;
var deltaY : float;

function Start () {

}

function Update () {
	x = Input.GetAxis("JoyHorizontal");
	y = Input.GetAxis("JoyVertical");
	
	stickVector = new Vector2(x,y);
	centerVector = new Vector2(0.0,0.0);
	
	angle = new Vector2.Angle(stickVector, centerVector);
	
	deltaX = x - 0;
	deltaY = y - 0;
	
	test = Mathf.Atan2(deltaY, deltaX) * 180 / 3.14;
	
	transform.localEulerAngles = Vector3(-test,90,-90);
}

function OnGUI(){
	text = "X: ";
	text += String.Format("{0}", x);
	text += String.Format("\nY: {0}", y);
	text += String.Format("\nStick Vector: {0}", stickVector); 
	text += String.Format("\nAngle: {0}", test);
    GUI.Label(Rect(0,0,Screen.width,Screen.height), text);
}
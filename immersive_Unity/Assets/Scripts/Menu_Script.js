public var loadingMessage : GameObject;

function Start () {
	loadingMessage.renderer.enabled = false;
}

function OnGUI () {
          // Make a background box
    GUI.Box (Rect (Screen.width/2-100,Screen.height/2+20,200,80), "");

    // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
    if (GUI.Button (Rect (Screen.width/2-90,Screen.height/2+40,180,20), "Menu")) {
        loadingMessage.renderer.enabled = true;
        Application.LoadLevel ("Menu");
    }

    // Make the second button.
    if (GUI.Button (Rect (Screen.width/2-90,Screen.height/2+70,180,20), "Kitchen Scene")) {
    	loadingMessage.renderer.enabled = true;
        Application.LoadLevel ("kitchen_scene");
    }
}
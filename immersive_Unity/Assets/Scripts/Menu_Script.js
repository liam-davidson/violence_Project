import System.IO;
import System;

static var levels : boolean[] = new boolean[2];
private var toggleLevel1 = false;
private var toggleLevel2 = false;
var userID : String;
public var loadingMessage : GameObject;

function Start () {
	loadingMessage.renderer.enabled = false;
}

function OnGUI () {
          // Make a background box
    GUI.Box (Rect (Screen.width/2-100,Screen.height/2+20,200,260), "");

    // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
    if (GUI.Button (Rect (Screen.width/2-90,Screen.height/2+40,180,20), "Menu")) {
        loadingMessage.renderer.enabled = true;
        writeText();
        Application.LoadLevel ("Menu");
    }

    // Make the second button.
    if (GUI.Button (Rect (Screen.width/2-90,Screen.height/2+70,180,20), "Kitchen Scene")) {
    	loadingMessage.renderer.enabled = true;
        writeText();
        Application.LoadLevel ("kitchen_scene");
    }
    
    GUI.Label (Rect (Screen.width/2-90, Screen.height/2+100, 180, 20), "Enter User ID:");
    userID = GUI.TextField (Rect (Screen.width/2-90, Screen.height/2+130, 180, 20), userID, 25);
    
    GUI.Label (Rect (Screen.width/2-90, Screen.height/2+160, 180, 20), "Select Levels:");
    toggleLevel1 = GUI.Toggle (Rect (Screen.width/2-90, Screen.height/2 + 190, 100, 30), toggleLevel1, "Scenario #1");
    toggleLevel2 = GUI.Toggle (Rect (Screen.width/2-90, Screen.height/2 + 220, 100, 30), toggleLevel2, "Scenario #2");
    
    if (GUI.Button (Rect (Screen.width/2-90,Screen.height/2+250,180,20), "Run Scenarios")) {
    	
    	writeText();
    	
    	levels[0] = toggleLevel1;
    	levels[1] = toggleLevel2;
    	
    	if (levels[0] == true){
    		Application.LoadLevel ("kitchen_scene");
    	}
    }
}

function writeText () {
	//sw = new StreamWriter("TestFile.txt");
	//sw.WriteLine(userID,true);
	//sw.WriteLine("-------------------");
	//sw = new StreamWriter("TestFile.txt");
	sw = File.AppendText ("TestFile.txt");
    sw.WriteLine ();
    sw.Write(userID);
    sw.Write(",");
    sw.Write(DateTime.Now);
    sw.Close();
}
import System.IO;
import System;

var userID : String;
public var loadingMessage : GameObject;

function Start () {
	loadingMessage.renderer.enabled = false;
}

function OnGUI () {
          // Make a background box
    GUI.Box (Rect (Screen.width/2-100,Screen.height/2+20,200,170), "");

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
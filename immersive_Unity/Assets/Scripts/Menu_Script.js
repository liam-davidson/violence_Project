import System.IO;
import System;

static var levels : boolean[] = new boolean[10];
private var toggleLevel1 = false;
private var toggleLevel2 = false;
private var toggleLevel3 = false;
private var toggleLevel4 = false;
private var toggleLevel5 = false;
private var toggleLevel6 = false;
private var toggleLevel7 = false;
private var toggleLevel8 = false;
private var toggleLevel9 = false;
private var toggleLevel10 = false;
var userID : String;
public var loadingMessage : GameObject;

function Start () {
	loadingMessage.renderer.enabled = false;
}

function OnGUI () {
          // Make a background box
    GUI.Box (Rect (Screen.width/2-150,50,300,500), "");

    // Button Example
    /*
    if (GUI.Button (Rect (Screen.width/2-90,Screen.height/2+40,180,20), "Menu")) {
        loadingMessage.renderer.enabled = true;
        writeText();
        Application.LoadLevel ("Menu");
    }
	*/
    
    GUI.Label (Rect (Screen.width/2-130, 60, 300, 20), "Enter User ID:");
    userID = GUI.TextField (Rect (Screen.width/2-130, 80, 180, 20), userID, 25);
    
    GUI.Label (Rect (Screen.width/2-130, 110, 180, 20), "Select Levels:");
    toggleLevel1 = GUI.Toggle (Rect (Screen.width/2-130, 130, 100, 20), toggleLevel1, "Scenario #1");
    toggleLevel2 = GUI.Toggle (Rect (Screen.width/2-130, 150, 100, 20), toggleLevel2, "Scenario #2");
    toggleLevel3 = GUI.Toggle (Rect (Screen.width/2-130, 170, 100, 20), toggleLevel3, "Scenario #3");
    toggleLevel4 = GUI.Toggle (Rect (Screen.width/2-130, 190, 100, 20), toggleLevel4, "Scenario #4");
    toggleLevel5 = GUI.Toggle (Rect (Screen.width/2-130, 210, 100, 20), toggleLevel5, "Scenario #5");
    toggleLevel6 = GUI.Toggle (Rect (Screen.width/2-130, 230, 100, 20), toggleLevel6, "Scenario #6");
    toggleLevel7 = GUI.Toggle (Rect (Screen.width/2-130, 250, 100, 20), toggleLevel7, "Scenario #7");
    toggleLevel8 = GUI.Toggle (Rect (Screen.width/2-130, 270, 100, 20), toggleLevel8, "Scenario #8");
    toggleLevel9 = GUI.Toggle (Rect (Screen.width/2-130, 290, 100, 20), toggleLevel9, "Scenario #9");
    toggleLevel10 = GUI.Toggle (Rect (Screen.width/2-130,310, 100, 20), toggleLevel10, "Scenario #10");
    
    if (GUI.Button (Rect (Screen.width/2-130,340,120,20), "Select All")) {
        toggleLevel1 = true;
		toggleLevel2 = true;
		toggleLevel3 = true;
		toggleLevel4 = true;
		toggleLevel5 = true;
		toggleLevel6 = true;
		toggleLevel7 = true;
		toggleLevel8 = true;
		toggleLevel9 = true;
		toggleLevel10 = true;
    }
    
    if (GUI.Button (Rect (Screen.width/2+10,340,120,20), "Clear")) {
	    toggleLevel1 = false;
		toggleLevel2 = false;
		toggleLevel3 = false;
		toggleLevel4 = false;
		toggleLevel5 = false;
		toggleLevel6 = false;
		toggleLevel7 = false;
		toggleLevel8 = false;
		toggleLevel9 = false;
		toggleLevel10 = false;
    }
    
    if (GUI.Button (Rect (Screen.width/2-130,520,120,20), "Run Scenarios")) {
    	
    	writeText();
    	
    	levels[0] = toggleLevel1;
    	levels[1] = toggleLevel2;
    	levels[2] = toggleLevel3;
    	levels[3] = toggleLevel4;
    	levels[4] = toggleLevel5;
    	levels[5] = toggleLevel6;
    	levels[6] = toggleLevel7;
    	levels[7] = toggleLevel8;
    	levels[8] = toggleLevel9;
    	levels[9] = toggleLevel10;
    	
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
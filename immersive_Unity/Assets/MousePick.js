#pragma strict
private var selected:Transform = null;
public var skillMax:int = 5;
function Update () {
	// clear the GUI buttons
	if(Input.GetButtonDown("Fire2")){
		selected = null;
	}
	if(Input.GetButtonDown("Fire1")){
		var hit:RaycastHit;
		if(Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), hit)){
			selected = hit.transform;
		}
	}
	
	if(Input.GetAxis("Vertical")){
		transform.position.y+=(Time.deltaTime*Input.GetAxis("Vertical")*10);
	}
	if(Input.GetAxis("Horizontal")){
		transform.position.x-=(Time.deltaTime*Input.GetAxis("Horizontal")*10);
	}
}

// how much to spread the icons apart
public var offset:Vector2 = Vector2(100, 100);
// offset where icon 0 begins (90 is the top)
public var degOffset:float = 90.0;
// width and height of the icons...
public var iconSize:Vector2 = Vector2(48, 32);

function OnGUI(){
	if(null != selected){
		// amount to offset each icon around the center
		var radialTic:float = (360/skillMax)*Mathf.Deg2Rad;
		// used to offset where '0' starts
		var radOffset:float = degOffset*Mathf.Deg2Rad;
		// position of the object
		var objPos:Vector3 = camera.WorldToScreenPoint(selected.collider.bounds.center);
		for(var i = 0; i < skillMax; ++i){
			var rad:float = (i*radialTic)+radOffset;
			var guiX:float = objPos.x+Mathf.Cos(rad)*offset.x;
			var guiY:float = objPos.y+Mathf.Sin(rad)*offset.y;
			// hug the screen
			guiX = Mathf.Clamp(guiX, 0, Screen.width);
			guiY = Mathf.Clamp(guiY, 0, Screen.height);
			if(GUI.Button(Rect(guiX-(iconSize.x*.5), Screen.height-(guiY+(iconSize.y*.5)), iconSize.x, iconSize.y), "Test"+i)){
				Debug.Log("Clicked Button "+i);
			}
		}
	}
}
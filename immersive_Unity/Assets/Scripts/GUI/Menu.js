
//http://ferventinteractive.com/blog/?p=41
#pragma strict

//public Texture2D emptyProgressBar;
//public Texture2D fullProgressBar;

public var emptyProgressBar : Texture2D;
public var fullProgressBar : Texture2D;

private var ray : Ray;
private var hit : RaycastHit;

function Start () {

}

function Test() {
	
	Debug.Log("Coroutine Start!");
	
	for (var f = 1.0; f >= 0; f -= 0.1)
	{
		Application.LoadLevelAdditive("kitchen_scene");
	}
	
	Debug.Log("Coroutine End!");
	
	yield;
}

function Update () {

	if (Input.GetKeyDown("f"))
	{
		Test();
	}

	if(Input.GetMouseButtonDown(0))
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if(Physics.Raycast(ray,hit)){
		
			if(hit.transform.name == "Start")
			{
				//Application.LoadLevelAdditive("kitchen_scene");
				Debug.Log("Loading Started...");
				Test();
			}
		}
	}
}
using UnityEngine;
using System.Collections;
[ExecuteInEditMode]

public class crosshair_GUI : MonoBehaviour {
	
	public _GUIClasses.TextureGUI crosshair = new _GUIClasses.TextureGUI();
	public _GUIClasses.Location location = new _GUIClasses.Location(); 
	public GUIStyle noGuiStyle;
	public Color GUIColor = Color.white;
	
	void Start () {
		useGUILayout = false;
	}
	
	void Update () {
		location.updateLocation();
	}
	
	void OnGUI(){
		GUI.color = GUIColor;
		GUI.Box(new Rect(location.offset.x + crosshair.offset.x,
						location.offset.y + crosshair.offset.y,
						crosshair.texture.width, crosshair.texture.height),
						crosshair.texture,noGuiStyle);
	}
	
}

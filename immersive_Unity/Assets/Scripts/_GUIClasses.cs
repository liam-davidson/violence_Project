using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _GUIClasses : MonoBehaviour
{
	
	// TextureGUI Class: create a basic class for creating and placing GUI elements
// texture = the texture to display
// offset = pixel offset from top left corner, can be modified for easy positioning
[System.Serializable]
public class TextureGUI 
	{
	public Texture texture; //useful: texture.width, texture.height
	public Vector3 offset; // .x and .y
	public Vector2 originalOffset; //store the original to correctly reset anchor point
	public enum Point { TopLeft, TopRight, BottomLeft, BottomRight, Center} //what part of texture to position around?
	
	public Point anchorPoint = Point.TopLeft; // Unity default is from top left corner of texture
		
	void setAnchor() 
		{ // meant to be run ONCE at Start.
		originalOffset = offset;
		if (texture) 
			{ // check for null texture
			switch(anchorPoint) { //depending on where we want to center our offsets
				case Point.TopLeft: // Unity default, do nothing
					break;
				case Point.TopRight: // Take the offset and go to the top right corner
					offset.x = originalOffset.x - texture.width;
					break;
					
				case Point.BottomLeft: // bottom left corner of texture
					offset.y = originalOffset.y - texture.height;
					break;
					
				case Point.BottomRight: //bottom right corner of texture
					offset.x = originalOffset.x - texture.width;
					offset.y = originalOffset.y - texture.height;
					break;
					
				case Point.Center: //and the center of the texture (useful for screen center textures)
					offset.x = originalOffset.x - texture.width/2;
					offset.y = originalOffset.y - texture.height/2;
					break;
			}
		}
	}	
}



// Location class: 
[System.Serializable]
public class Location 
	{
	public enum Point { TopLeft, TopRight, BottomLeft, BottomRight, Center}
	
	public Point pointLocation = Point.TopLeft;
	public Vector2 offset;
	
		
	public void updateLocation() 
		{
		switch(pointLocation) 
			{
			case Point.TopLeft:
				offset = new Vector2(0,0);
				break;
			case Point.TopRight:
				offset = new Vector2(Screen.width,0);
				break;
				
			case Point.BottomLeft:
				offset = new Vector2(0,Screen.height);
				break;
				
			case Point.BottomRight:
				offset = new Vector2(Screen.width,Screen.height);
				break;
				
			case Point.Center:
				offset = new Vector2(Screen.width/2,Screen.height/2);
				break;
		}		
	}
}

}

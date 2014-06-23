using UnityEngine;
using System.Collections;

public class crosshair : MonoBehaviour {

	public float range = 2.0f;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
		
		RaycastHit hit = new RaycastHit();
		Debug.DrawRay(ray.origin, ray.direction, Color.green);
		
		if(Physics.Raycast(ray, out hit, range)){
			
			if(hit.collider.gameObject.GetComponent<UseableItem>() != null){
				
				hit.collider.gameObject.GetComponent<UseableItem>().OnLookEnter();
			}
			
			if(hit.collider.gameObject.GetComponent<CharacterInteract>() != null){
				
				hit.collider.gameObject.GetComponent<CharacterInteract>().OnLookEnter();
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class UseableItem : MonoBehaviour {
	
	public Material defaultMaterial;
	public Material glowMaterial;
	
	public GUIText target;
	
	public bool itemUseable = true;
	private bool holdingItem = false;
	
	public GameObject ItemToHold;
	//public Transform ItemToHold;
	
	void Start(){
		renderer.material = new Material(defaultMaterial);
	}
	
	void FixedUpdate(){
		target.text = "";
		renderer.material = defaultMaterial;
	}
	
	public void OnLookEnter(){
		if(itemUseable){
		
			target.text = "Press E";
			renderer.material = glowMaterial;
			if(Input.GetKeyDown(KeyCode.E)){
				itemUseable = false;
				
				//var Item1 = Instantiate (ItemToHold, GameObject.FindGameObjectWithTag("Hand").transform.parent.position, Quaternion.identity);
				//Instantiate (ItemToHold, transform.position, Quaternion.identity);
				var Item1 = Instantiate (ItemToHold, GameObject.FindWithTag("Hand").transform.parent.position, Quaternion.identity) as GameObject;
				Item1.transform.parent = GameObject.Find("R_WeaponNode").transform;
	
				Destroy(gameObject);
			}
		}
	}
	
}

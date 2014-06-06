using UnityEngine;
using System.Collections;

public class FocusOnPlayer : MonoBehaviour {

	public Transform targetFollow;
	public GameObject head;
	public GameObject spine;

	private float maxHeadRot, maxSpineRot;
	public float smooth = 0.3F;
	public float distance = 5.0F;

	Vector3 adjustRot = new Vector3(0, -90, -90);
	int damp = 5;
	// Use this for initialization
	void Awake(){
		maxHeadRot = 85.0f;
		maxSpineRot = 35.0f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 point = targetFollow.position;
		Vector3 v3Dir = targetFollow.position - transform.position;
		
		var rotation = Quaternion.LookRotation (v3Dir);
		var eulerRotation = rotation.eulerAngles;
		
		if (Mathf.Abs (eulerRotation.y - 180) < maxHeadRot) {
			head.transform.LookAt (point);		
			head.transform.Rotate (adjustRot);
		} 
		
		if (Mathf.Abs (eulerRotation.y - 180) < maxSpineRot) {
			
			spine.transform.LookAt(point);
			spine.transform.Rotate(adjustRot);
		}

		var lookPos = targetFollow.position - transform.position;
		lookPos.y = 0;
		
		var rotationAngle = Quaternion.LookRotation (lookPos);
		transform.rotation = Quaternion.Slerp ( transform.rotation, rotationAngle, Time.deltaTime * damp);

	}
}

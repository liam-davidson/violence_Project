using UnityEngine;
using System.Collections;

public class SmoothLook : MonoBehaviour {
	public Transform target;
	int damping = 6;
	bool smooth = true;
	// Use this for initialization
	void Start () {
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(target){
			var rotation = Quaternion.LookRotation(target.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
		}
		else{
			transform.LookAt(target);
		}
	}
}

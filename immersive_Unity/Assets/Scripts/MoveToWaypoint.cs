using UnityEngine;
using System.Collections;

public class MoveToWaypoint : MonoBehaviour {

	//public Transform[] waypoints;
	//Transform waypoint;
	public MoveToWaypoint moving;

	public Transform currentWaypoint;
	private int currentIndex;

	public float moveSpeed = 10.0f;
	public float minDistance = 1.0f;
	// Use this for initialization
	void Start () {
		//currentWaypoint = waypoints [0];
		//currentWaypoint = waypoint;
		currentIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {

		float tempf = Vector3.Distance (currentWaypoint.transform.position, transform.position);
		tempf = Mathf.Round(tempf * 10f) / 10f;
		print (tempf);

		if (tempf != 0) {
			MoveTowardWaypoint ();
		} 

	}
	void MoveTowardWaypoint(){

		print ("Dist = " + Vector3.Distance (currentWaypoint.transform.position, transform.position));

		Vector3 direction = currentWaypoint.transform.position - transform.position;
		Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
		//transform.position += moveVector;

		transform.position = Vector3.Lerp(transform.position, currentWaypoint.transform.position, Time.deltaTime); // move
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 4 * Time.deltaTime);
	}

	public void changeWaypoint(){
		//waypoint = newWaypoint;
	}
}

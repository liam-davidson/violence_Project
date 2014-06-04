using UnityEngine;
using System.Collections;

public class UniformBSplineControlPoint : MonoBehaviour {

	[HideInInspector]
	public Vector3 cachedPosition;
	
	// Use this for initialization
	void Start ()
	{
		
		cachedPosition = transform.position;
		
	}
	
	void OnDrawGizmos()
	{
		
		cachedPosition = transform.position;
		
		// Draw control point
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(cachedPosition, 0.1f);
		
	}
}

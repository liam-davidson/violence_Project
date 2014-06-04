using UnityEngine;
using System.Collections;

public class UniformBSplineMover_C : MonoBehaviour {
	
	public UniformBSpline path;

	public float time;

	// Use this for initialization
	void Start () {

		StartCoroutine(Move());
		
	}
	
	void Update () {

	}
	
	private IEnumerator Move()
	{

		
		for(float t = 0.0f; t < 1.0f; t += Time.deltaTime * (1/time))
		{
			transform.position = path.Evaluate(t);
			yield return 0;
		}
		
		transform.position = path.Evaluate(1.0f);

	}
}
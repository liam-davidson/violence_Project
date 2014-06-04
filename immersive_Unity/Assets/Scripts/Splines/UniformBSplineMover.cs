using UnityEngine;
using System.Collections;

public class UniformBSplineMover : MonoBehaviour {

	private Animator anim;

	public UniformBSpline path;
	
	public float time;
	
	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator>();
		//StartCoroutine(Move());
		
	}

	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			StartCoroutine(Move());		
		}			
	}

	private IEnumerator Move()
	{
		anim.SetBool ("isWalking", true);

		for(float t = 0.0f; t < 1.0f; t += Time.deltaTime * (1/time))
		{
			Debug.Log (t);
			anim.SetFloat("Time", t);
			transform.position = path.Evaluate(t);
			yield return 0;
		}
		
		transform.position = path.Evaluate(1.0f);

		anim.SetBool ("isWalking", false);
	}
}

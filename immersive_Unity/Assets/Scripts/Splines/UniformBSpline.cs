using UnityEngine;
using System.Collections;

public class UniformBSpline : MonoBehaviour {

	public UniformBSplineControlPoint[] m_controlPoints;
	
	[HideInInspector]
	public float startTime = 0.0f;
	
	[HideInInspector]
	public float endTime = 1.0f;
	
	private int count;
	
	private Vector3[] positions;
	private float[] times;
	
	// Use this for initialization
	void Start ()
	{
	
		Initialize();
		
	}
	
	private bool Initialize()
	{
		if( m_controlPoints.Length != 0)
		{
		
			positions = new Vector3[m_controlPoints.Length + 4];
			times = new float[m_controlPoints.Length + 2];
		
			count = m_controlPoints.Length + 4;
		
			// Copy positions data (triplicate start and en points so that curve passes trough them.)
			positions[0] = positions[1] = m_controlPoints[0].cachedPosition;
		
			for(int i = 0; i < m_controlPoints.Length; ++i)
			{
				positions[i + 2] = m_controlPoints[i].cachedPosition;
			}
		
			positions[count - 1] = positions[count - 2] = m_controlPoints[m_controlPoints.Length - 1].cachedPosition;
		
			// Setup times (subdivide interval to get arrival times at each knot location)
			float dt = (endTime - startTime) / (float)(m_controlPoints.Length + 1);
		
			times[0] = startTime;
			for(int i = 0; i < m_controlPoints.Length; ++i)
			{
				times[i + 1] = times[i] + dt;
			}
			times[m_controlPoints.Length + 1] = endTime;
		
		
			//Debug.Log("Initialize success.");
			return true;
		}
		
		Debug.Log("Initialize failed.");
		return false;
		
	}
	
	// PUBLIC INTERFACE
	
	public void Clean()
	{
		positions = null;
		times = null;
		count = 0;
	}

	public Vector3 Evaluate(float t)
	{
		
		if( count < 6 )
			return Vector3.zero;
		
		// Handle boundry conditions
		if( t <= times[0] )
		{
			return positions[0];
		}
		else if ( t >= times[count - 3] )
		{
			return positions[count - 3];
		}
		
		// Find segment and parameter
		
		int segment = 0;
		while(segment < count - 3)
		{
			
			if( t <= times[segment + 1] )
			{
				break;
			}
			
			segment++;
			
		}
		
		float t0 = times[segment];
		float t1 = times[segment + 1];
		float u = (t - t0) / (t1 - t0);
		
		// match segment index to standard B-spline terminology
		segment += 3;
		
		// Evaluate
		Vector3 A = positions[segment] - 3.0f * positions[segment - 1] + 3.0f * positions[segment - 2] - positions[segment - 3];
		Vector3 B = 3.0f * positions[segment - 1] - 6.0f * positions[segment - 2] + 3.0f * positions[segment - 3];
		Vector3 C = 3.0f * positions[segment - 1] - 3.0f * positions[segment - 3];
		Vector3 D = positions[segment - 1] + 4.0f * positions[segment - 2] + positions[segment - 3];
		
		return (D + u * (C + u * (B + u * A))) / 6.0f;
	}
	
	public Vector3 Velocity(float t)
	{
		return Vector3.zero;
	}
	
	public Vector3 Aceleration(float t)
	{
		return Vector3.zero;
	}
	
	// Render
	void OnDrawGizmos()
	{
		
		Initialize();
		
		Gizmos.color = Color.blue;
		
		Vector3 start = Evaluate(0.0f);
		Vector3 end = Vector3.zero;
		
		for(float t = startTime; t < endTime; t += 0.01f)
		{
			
			end = Evaluate(t);
			
			Gizmos.DrawLine(start, end);
			
			start = end;
			
		}
		
	}
	
}

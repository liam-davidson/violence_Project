using UnityEngine;
using System.Collections;

public class LoadFade : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.CameraFadeAdd ();
		iTween.CameraFadeFrom (1,1);
	}
}

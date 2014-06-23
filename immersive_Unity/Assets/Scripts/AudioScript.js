#pragma strict

public var menuAudio1 : AudioClip;
public var menuAudio2 : AudioClip;

function Start () {

}

function Update () {

}

public function playAudio (clipNumber : int, volume : float) {
	if(clipNumber == 1) {
		AudioSource.PlayClipAtPoint(menuAudio1,new Vector3(0,0,0),volume);
	}
	
	if(clipNumber == 2) {
		AudioSource.PlayClipAtPoint(menuAudio2,new Vector3(0,0,0),volume);
	}
}
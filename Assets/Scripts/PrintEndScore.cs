using UnityEngine;
using System.Collections;

public class PrintEndScore : MonoBehaviour {

	public Font greekFont;
	bool canSwitch = false;
	bool waitActive = false; //so wait function wouldn't be called many times per frame

	IEnumerator Wait(){
		waitActive = true;
		yield return new WaitForSeconds (20.0f);
		canSwitch = true;
		waitActive = false;
	}

    void OnGUI() {
        GUIStyle style = new GUIStyle();
        style.fontSize = 100;
        style.normal.textColor = Color.white;
		style.font = greekFont;
		GUI.Label(new Rect(Screen.height-200, Screen.width/7, 20, 20), "Game OVer", style);
		style.fontSize = 50;
		GUI.Label(new Rect(Screen.height/3, Screen.width/4, 20, 20), "The Game will restart in a few secOnds", style);
		if(!waitActive){
			StartCoroutine(Wait());   
		}
		if(canSwitch){
			Application.LoadLevel(0);
			canSwitch = false;
		}
	}
}

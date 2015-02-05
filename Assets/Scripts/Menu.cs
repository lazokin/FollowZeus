using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{	
	public GUIStyle exit;
	public GUIStyle play;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() {
		if (GUI.Button(new Rect(Screen.width/3,Screen.height/3*2, 250, 150), "", play))
			Application.LoadLevel(1);
		if (GUI.Button(new Rect(Screen.width/3*2,Screen.height/3*2, 250,150), "", exit))
			Application.Quit();
	}
}

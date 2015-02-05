using UnityEngine;
using System.Collections;

public class PosTxt : MonoBehaviour
{	
	public GUIText text;

	// Use this for initialization
	void Start () {
		if (Screen.width < 1280)
			text.fontSize = 50;
		text.pixelOffset = new Vector2(Screen.width / 2, Screen.height / 2);
	}
	
	// Update is called once per frame
	void Update () {
	}
}

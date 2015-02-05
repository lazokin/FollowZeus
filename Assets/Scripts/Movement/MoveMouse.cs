using UnityEngine;
using System.Collections;

public class MoveMouse : MonoBehaviour
{
	public int sensitivity;

	void  Update (){
		//left
		if(Input.mousePosition.x < sensitivity)
			transform.Translate(Vector3.left * Time.deltaTime * Mathf.Abs(sensitivity - Input.mousePosition.x));
		//right
		if(Input.mousePosition.x > Screen.width - sensitivity)
			transform.Translate(Vector3.right * Time.deltaTime * Mathf.Abs(Screen.width - Input.mousePosition.x));
		//down
		if(Input.mousePosition.y < sensitivity)
			transform.Translate(Vector3.down * Time.deltaTime * Mathf.Abs(sensitivity - Input.mousePosition.y));
		//up
		if(Input.mousePosition.y > Screen.height - sensitivity)
			transform.Translate(Vector3.up * Time.deltaTime * Mathf.Abs(Screen.height - Input.mousePosition.y));
	}
}
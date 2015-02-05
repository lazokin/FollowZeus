using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour
{
	public Transform target;
	public int speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
}

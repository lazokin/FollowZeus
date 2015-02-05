﻿using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	public int moveSpeed = 10;	
	public Vector3 instantVelocity;
	
	void  Start()
	{
		instantVelocity = Vector3.zero;
	}
	
	void  Update()
	{
		Vector3 pos = transform.position;	
		float horMovement= Input.GetAxis("Horizontal");
		float forwardMovement= Input.GetAxis("Vertical");
		
		transform.Translate(transform.right * horMovement * Time.deltaTime * moveSpeed);
		transform.Translate(transform.forward * forwardMovement * Time.deltaTime * moveSpeed);
		instantVelocity = transform.position - pos;
	}
}
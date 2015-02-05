using UnityEngine;
using System.Collections;

public class FlockController : MonoBehaviour 
{
	public float cohesionRadius = 30;
	public float cohesionWeight = 10;
	public float separationRadius = 15;
	public float separationWeight = 30;
	public float maxAcceleration = 50;

	void Start() 
	{
		GameObject[] preys;
		preys = GameObject.FindGameObjectsWithTag("Prey");
		foreach (GameObject prey in preys)
			prey.transform.parent = transform;
	}
}

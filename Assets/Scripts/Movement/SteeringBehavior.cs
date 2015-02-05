using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SteeringBehavior : MonoBehaviour
{
	#region Variables

	#region Movement
    public Transform target;
    public float moveSpeed = 6.0f;
    public float rotationSpeed = 1.0f;
    private int minDistance = 5;
    private int safeDistance = 60;
	#endregion

	#region State
    public enum AIState
    {
        Idle,
        Seek,
        Flee,
        Arrive,
        Pursuit,
        Evade
    }
    public AIState currentState;
	#endregion

	#region Obstacles
    public int range = 20;
    private bool objectHere = false;
    private RaycastHit hit;
	#endregion

	#region Flocking
    private GameObject[] preyArray;
    private FlockController flockController;
	#endregion

	#endregion

    void Start()
    {
        preyArray = GameObject.Find("Level Manager").GetComponent<LevelData>().PreyArray;
        flockController = GetComponentInParent<FlockController>();
    }

    void FixedUpdate()
    {
        if (currentState != AIState.Idle)
        {
            if (Physics.Raycast(transform.position + (transform.right * 2), transform.forward, out hit, range)
                || Physics.Raycast(transform.position - (transform.right * 2), transform.forward, out hit, range)
                || Physics.Raycast(transform.position, transform.right, out hit, 5)
                || Physics.Raycast(transform.position, -transform.right, out hit, 5))
            {
                if (hit.collider.gameObject.CompareTag("Obstacle"))
                    transform.Rotate(0, 10 * Time.deltaTime * rotationSpeed, 0);
            }
            Vector3 direction = target.position - transform.position;	
            direction.y = 0;
            if (Physics.Raycast(transform.position, direction, out hit))
            {
                if (hit.distance <= 10 && hit.collider.gameObject.CompareTag("Obstacle"))
                    objectHere = true;
                else
                    objectHere = false;
            }
            if (!objectHere)
            {
                switch (currentState)
                {
                    case AIState.Seek:
                        Seek();
                        break;
                    case AIState.Flee:
                        Flee();
                        break;
                    case AIState.Arrive:
                        Arrive();
                        break;
                    case AIState.Pursuit:
                        Pursuit();
                        break;
                    case AIState.Evade:
                        Evade();
                        break;
                }
            } else
                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        Vector3 acceleration = Cohesion() * flockController.cohesionWeight;
        acceleration += Separation() * flockController.separationWeight;
        acceleration = Vector3.ClampMagnitude(acceleration, flockController.maxAcceleration);
        rigidbody.AddForce(acceleration * Time.fixedDeltaTime);		
    }

	#region Flocking
    Vector3 Cohesion()
    {
        Vector3 vectors = new Vector3();
        int ct = 0;

        if (preyArray != null)
        {
            foreach (GameObject prey in preyArray)
            {
                float distance = Vector3.Distance(rigidbody.position, prey.rigidbody.position);
                if (distance > 0 && distance < flockController.cohesionRadius)
                {
                    vectors += prey.rigidbody.position;
                    ct++;
                }
            }
        }

        if (ct > 0)
            return ((vectors / ct) - rigidbody.position);
        return (vectors);
    }

    Vector3 Separation()
    {
        Vector3 vectors = new Vector3();
        int ct = 0;
		
        if (preyArray != null)
        {
            foreach (GameObject prey in preyArray)
            {
                float distance = Vector3.Distance(rigidbody.position, prey.rigidbody.position);
                
                if (distance > 0 && distance < flockController.separationRadius)
                {
                    vectors += (rigidbody.position - prey.rigidbody.position).normalized / distance;
                    ct++;
                }
            }
        }

        if (ct > 0)
            return (vectors /= ct);
        return (vectors);
    }
	#endregion

	#region State
    void Seek()
    {
        Vector3 direction = target.position - transform.position;
		
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        if (direction.magnitude > minDistance)
        {
            Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;	
            transform.position += moveVector;
        }
    }
	
    void Flee()
    {
        Vector3 direction = transform.position - target.position;
		
        direction.y = 0;
        if (direction.magnitude < safeDistance)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
            transform.position += moveVector;
        }
    }
	
    void Arrive()
    {
        Vector3 direction = target.position - transform.position;
		
        direction.y = 0;
		
        float distance = direction.magnitude;
        float decelerationFactor = distance / 5;		
        float speed = moveSpeed * decelerationFactor;
		
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
		
        Vector3 moveVector = direction.normalized * Time.deltaTime * speed;
		
        transform.position += moveVector;
    }
	
    void Pursuit()
    {
        int iterationAhead = 30;	
        //Vector3 targetSpeed= target.gameObject.GetComponent<Move>().instantVelocity;
        Vector3 targetSpeed = target.gameObject.rigidbody.velocity;
        Vector3 targetFuturePosition = target.transform.position + (targetSpeed * iterationAhead);
        Vector3 direction = targetFuturePosition - transform.position;
		
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        if (direction.magnitude > minDistance)
        {	
            Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;	
            transform.position += moveVector;
        }
    }
	
    void Evade()
    {
        int iterationAhead = 30;
        //Vector3 targetSpeed= target.gameObject.GetComponent<Move>().instantVelocity;
        Vector3 targetSpeed = target.gameObject.rigidbody.velocity;
        Vector3 targetFuturePosition = target.position + (targetSpeed * iterationAhead);
        Vector3 direction = transform.position - targetFuturePosition;
		
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        if (direction.magnitude < safeDistance)
        {
            Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;	
            transform.position += moveVector;
        }
    }
	#endregion
}
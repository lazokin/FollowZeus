using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Arrive arrive;
    private MovementController movementController;
    private Vector3 moveToPoint;

    private MachineLearningLogger machineLearningLogger;

    public GameObject thunder;
    public GameObject bolt;

    public float strikeRadius = 1;
    public float StrikeRadius
    {
        get
        {
            return strikeRadius;
        }
    }

    public float boltRadius = 1;
    public float BoltRadius
    {
        get
        {
            return boltRadius;
        }
    }

    private int numberOfFollowers = 0;
    public int NumberOfFollowers
    {
        get
        {
            return numberOfFollowers;
        }
        set
        {
            numberOfFollowers = value;
        }
    }

    void Start()
    {
        arrive = GetComponent<Arrive>();
        movementController = GetComponent<MovementController>();
        moveToPoint = transform.position;
        machineLearningLogger = new MachineLearningLogger();
    }
	
    void Update()
    {
        Debug.DrawLine(new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z), new Vector3(gameObject.transform.position.x, 10, gameObject.transform.position.z), Color.red);
        // Check for right click on predator
        if (Input.GetKeyDown(KeyCode.Space))
        {
            machineLearningLogger.LogBolt();
            if (LevelData.ammoBolt > 0)
            {
                if (!bolt.particleSystem.isPlaying)
                    bolt.particleSystem.Play();

                if (!this.audio.isPlaying)
                    this.audio.Play();
                Vector3 targetPoint = gameObject.transform.position;
                targetPoint.y = 0;
                
                GameObject[] predatorArray = GameObject.FindGameObjectsWithTag("Predator");
                foreach (GameObject predator in predatorArray)
                {
                    float distanceToPredator = (targetPoint - new Vector3(predator.transform.position.x, 0, predator.transform.position.z)).magnitude;
                    if (distanceToPredator < strikeRadius)
                        Destroy(predator);
                }
                LevelData.ammoBolt -= 1;
            }
        } else if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
        {
            machineLearningLogger.LogStrike();
            if (LevelData.ammoStrike > 0)
            {
                if (!thunder.particleSystem.isPlaying)
                    thunder.particleSystem.Play();
                if (!this.audio.isPlaying)
                    this.audio.Play();
                Vector3 targetPoint = gameObject.transform.position;
                targetPoint.y = 0;
                
                GameObject[] predatorArray = GameObject.FindGameObjectsWithTag("Predator");
                foreach (GameObject predator in predatorArray)
                {
                    float distanceToPredator = (targetPoint - new Vector3(predator.transform.position.x, 0, predator.transform.position.z)).magnitude;
                    if (distanceToPredator < boltRadius)
                        predator.GetComponent<StateMachinePredator>().HitByStrike();
                }
                LevelData.ammoStrike -= 1;
            }
        }

        // Check for left click for movement
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            moveToPoint = ray.GetPoint(Camera.main.transform.position.y);
            moveToPoint.y = 0;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }

        movementController.Move(
            arrive.LinearAcceleration(moveToPoint),
            arrive.AngularAcceleration(moveToPoint)
        );
    }

}

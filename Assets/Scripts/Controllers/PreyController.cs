using UnityEngine;
using System.Collections;

public class PreyController : MonoBehaviour
{
    public float startFollowDistance = 1;
    public float StartFollowDistance
    {
        get
        {
            return startFollowDistance;
        }
    }

    public float breakFollowDistance = 1;
    public float BreakFollowDistance
    {
        get
        {
            return breakFollowDistance;
        }
    }

    public float startEvadeDistance = 1;
    public float StartEvadeDistance
    {
        get
        {
            return startEvadeDistance;
        }
    }
    
    public float breakEvadeDistance = 1;
    public float BreakEvadeDistance
    {
        get
        {
            return breakEvadeDistance;
        }
    }

    public float safeZoneSprintDistance = 1;
    public float SafeZoneSprintDistance
    {
        get
        {
            return safeZoneSprintDistance;
        }
    }

    private LevelData levelData;

    void Start()
    {
        levelData = GameObject.Find("Level Manager").GetComponent<LevelData>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Destroy prey when contact with safe zone
        if (collision.collider.gameObject.tag == "SafeZone")
        {
            LevelData.savedNumberOfPrey++;
            Debug.Log("Saved = " + LevelData.savedNumberOfPrey);
            Destroy(gameObject);
        }

        // Destroy prey when contact with safe zone
        if (collision.collider.gameObject.tag == "Predator")
        {
            LevelData.lostNumberOfPrey++;
            Debug.Log("Lost = " + LevelData.lostNumberOfPrey);
            Destroy(gameObject);
        }
            
    }

    void OnDestroy()
    {
        levelData.PreyArray = GameObject.FindGameObjectsWithTag("Prey");
    }

}

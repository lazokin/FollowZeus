using UnityEngine;
using System.Collections;

[RequireComponent(typeof(KineticDrive))]
public class KeyboardMovement : MonoBehaviour
{

    private KineticDrive kineticDrive;

    protected void Awake()
    {
        kineticDrive = GetComponent<KineticDrive>();
    }
	
    protected void Update()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        kineticDrive.Drive(direction);
    }
}

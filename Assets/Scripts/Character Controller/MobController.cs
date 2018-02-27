using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour {

    Rigidbody body;

    public int velocity = 12;
    public int rotationalForce = 4;

    public GameObject[] waypoints = new GameObject[2];
    private int waypointIndex, waitTimer;

    // Use this for initialization
    void Start ()
    {
        body = GetComponent<Rigidbody>();
        waypointIndex = waitTimer = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        patrolWaypoints();
	}

    void patrolWaypoints()
    {
        if (waitTimer > 0)
        {
            waitTimer -= 1;
            return;
        }

        GameObject destination = waypoints[waypointIndex];

        if (Mathf.Ceil(body.position.x) == Mathf.Ceil(destination.transform.position.x) && Mathf.Ceil(body.position.z) == Mathf.Ceil(destination.transform.position.z))
        {
            body.velocity = Vector3.zero;
            waitTimer = 180;
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
        else
        {
            var direction = destination.transform.position - body.position;
            direction.y = 0;
            direction = direction / (direction.magnitude);

            body.rotation = Quaternion.RotateTowards(body.rotation, Quaternion.LookRotation(direction), rotationalForce);
            body.velocity = transform.forward * velocity;
        }
    }
}

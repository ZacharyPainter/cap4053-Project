using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float forwardVelocity = 12, targetDistance, lookDistance, attackDistance, damping = 10;
	public Transform target;

	Quaternion targetRotation;
	Rigidbody body;
	float forwardInput, sideInput, horizontalRotation, verticalRotation;
	private GameObject player;
	bool fireInput;
	enum State {Wandering, Pursuing, Seeking};
	State state;
	Renderer myRender;

	public Quaternion TargetRotation {
		get { return targetRotation; }
	}

	// Use this for initialization
	void Start()
	{
		targetRotation = transform.rotation;
		body = GetComponent<Rigidbody>();
		myRender = GetComponent<Renderer> ();
		player = GameObject.Find ("Wizard");
		state = State.Wandering;

		forwardInput = sideInput = 0;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		switch (state)
		{
		/*case State.Pursuing:
			Pursue ();
			break;*/
		case State.Wandering:
			Wander ();
			break;
		}
	}

	void Wander()
	{
		target.position = Random.insideUnitCircle * 5;

		lookAtTarget ();
		move ();
	}

	void Pursue()
	{
		//set vectors for pursuing
		Vector3 start = transform.position;
		Vector3 direction = player.transform.position - transform.position;

		forwardInput = Input.GetAxis("Vertical");
		sideInput = Input.GetAxis("Horizontal");
		fireInput = Input.GetButton("Fire1");


		horizontalRotation = Input.GetAxis("TurnHorizontal");
		verticalRotation = Input.GetAxis("TurnVertical");

		RaycastHit playerInSight;
		Physics.Linecast (start, direction, out playerInSight);

		if (playerInSight.collider.CompareTag ("Player")) {
			fireInput = true;
		} else {
			state = State.Wandering;
		}
	}

	void move()
	{
		body.AddForce (transform.forward * forwardVelocity);
	}

	void lookAtTarget()
	{
		Quaternion rotation = Quaternion.LookRotation (target.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
	}

}

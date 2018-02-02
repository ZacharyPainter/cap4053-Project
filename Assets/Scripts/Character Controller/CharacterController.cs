using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	public float forwardVelocity = 12;

	Quaternion targetRotation;
	Rigidbody body;
	float forwardInput, sideInput;

	public Quaternion TargetRotation {
		get { return targetRotation; }
	}

	// Use this for initialization
	void Start () 
	{
		targetRotation = transform.rotation;
		body = GetComponent<Rigidbody>();

		forwardInput = sideInput = 0;
	}

	// Update is called once per frame
	void Update () 
	{
		GetInput();
		Run();
	}

	void GetInput () 
	{
		forwardInput = Input.GetAxis("Vertical");
		sideInput = Input.GetAxis("Horizontal");
	}

	void Run()
	{
		body.velocity = transform.forward * (forwardInput * forwardVelocity) + transform.right * (sideInput * forwardVelocity);
	}

	void Turn()
	{
	}
}

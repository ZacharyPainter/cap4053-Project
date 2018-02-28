using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class CharacterController : MonoBehaviour {

    public float forwardVelocity = 50.0f;

    Quaternion targetRotation;
    Rigidbody body;
    float forwardInput, sideInput, horizontalRotation, verticalRotation, fireInput;

	public XboxController playerNumber = XboxController.First;

    public Quaternion TargetRotation {
        get { return targetRotation; }
    }

    // Use this for initialization
    void Start()
    {
        targetRotation = transform.rotation;
        body = GetComponent<Rigidbody>();

        forwardInput = sideInput = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();
        Run();
    }

    void GetInput()
    {
		forwardInput = XCI.GetAxis(XboxAxis.LeftStickY, playerNumber);
		sideInput = XCI.GetAxis (XboxAxis.LeftStickX, playerNumber);
		fireInput = XCI.GetAxis (XboxAxis.RightTrigger, playerNumber);

		horizontalRotation = XCI.GetAxis (XboxAxis.RightStickX, playerNumber);
		verticalRotation = XCI.GetAxis (XboxAxis.RightStickY, playerNumber);
    }

    void Run()
    {
        body.velocity = new Vector3(0,0,1) * (forwardInput * forwardVelocity) + new Vector3(1,0) * (sideInput * forwardVelocity);

        if (horizontalRotation > .19 || verticalRotation > .19 || horizontalRotation < -.19 || verticalRotation < -.19)
        {
            Quaternion rotation = Quaternion.LookRotation(new Vector3(horizontalRotation, 0, verticalRotation));
            transform.rotation = rotation;
        }

		if (fireInput > 0)
            GetComponent<CharacterWeapon>().handleFire();
	}

}

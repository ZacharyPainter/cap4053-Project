using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	public GameObject player;
	private NavMeshAgent nav;
	private Vector3 prevNavPos;

	private string state = "idle";
	private bool alive = true;

	// Use this for initialization
	void Start()
	{
		nav = GetComponent<NavMeshAgent> ();

	}

	// Update is called once per frame
	void Update()
	{
		if (alive)
		{
			if (state == "idle")
			{
				Vector3 randomPos = Random.insideUnitSphere * 30f;
				NavMeshHit navHit;
				NavMesh.SamplePosition (transform.position + randomPos, out navHit, 30f, NavMesh.AllAreas);
				nav.SetDestination (navHit.position);
				prevNavPos = navHit.position;
				state = "walk";
			}

			if (state == "walk")
			{
				if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
				{
					state = "idle";
				}
			}	
		}
		//nav.SetDestination (player.transform.position);
	}
}

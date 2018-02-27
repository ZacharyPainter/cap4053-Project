using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterInventory>() != null)
        {
            other.gameObject.GetComponent<CharacterInventory>().pickupItem(gameObject);
            Destroy(gameObject);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour {

    private GameObject heldItem;

	// Use this for initialization
	void Start () {
		
	}
	
	public void pickupItem(GameObject item)
    {
        heldItem = item;
    }
}

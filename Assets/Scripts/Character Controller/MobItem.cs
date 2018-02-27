using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MobItem : MonoBehaviour {

    public GameObject[] dropTable = new GameObject[1];

	// Use this for initialization
	void Start ()
    {
		
	}
	
	public void dropItem(Vector3 position)
    {
        System.Random r = new System.Random();

        int randomItemIndex = r.Next() % dropTable.Length;

        var Item = (GameObject)Instantiate(dropTable[randomItemIndex], position, Quaternion.identity);
    }
}

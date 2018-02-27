using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public int damage = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterHealth>() != null)
        {
            //Deal damage to target
            other.gameObject.GetComponent<CharacterHealth>().takeDamage(3);
        }

        //Remove fireball from screen
        Destroy(gameObject);
    }
}

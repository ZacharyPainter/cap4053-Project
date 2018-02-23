using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public const int maxHealth = 10;
    public int health = maxHealth;

    public void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }
}

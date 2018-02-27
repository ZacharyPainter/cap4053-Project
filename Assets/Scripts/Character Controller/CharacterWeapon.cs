using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour {

    public float fireRate = 1;
    public float projectileSpeed = 16;
    public string currentWeapon = "Fireball";
    private float timeToFire = 0;
    public GameObject Fireball;

    Transform firePoint;

    public void handleFire()
    {
        firePoint = transform.Find("FirePoint");

        if (Time.time > timeToFire)
        {
            timeToFire = Time.time + (1 / fireRate);

            switch (currentWeapon)
            {
                case "Fireball":
                    var bullet = (GameObject)Instantiate(Fireball, firePoint.position, firePoint.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * projectileSpeed;
                    break;
                default:
                    break;
            }
        }
    }
}

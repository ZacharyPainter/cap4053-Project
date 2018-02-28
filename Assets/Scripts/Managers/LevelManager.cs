using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject PlayerWizard;
    public GameObject EnemyWizard;

    private Transform PlayerHolder;

    private Vector3 playerSpawnPosition = new Vector3(-8,-2,0);
    private Vector3 enemySpawnPosition = new Vector3(8, 2, 0);

    private Quaternion playerSpawnRotation = Quaternion.LookRotation(new Vector3(1,0,0));
    private Quaternion enemySpawnRotation = Quaternion.LookRotation(new Vector3(-1, 0, 0));

    public void setup()
    {
        PlayerHolder = new GameObject("Player").transform;

        var Player = (GameObject)Instantiate(PlayerWizard, playerSpawnPosition, playerSpawnRotation);
        Player.transform.SetParent(PlayerHolder);

        var Enemy = (GameObject)Instantiate(EnemyWizard, enemySpawnPosition, enemySpawnRotation);
        Enemy.transform.SetParent(PlayerHolder);
    }
}

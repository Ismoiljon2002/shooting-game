using UnityEngine;
using System.Collections;

public class enemyGenerator : MonoBehaviour {

    public GameObject alien;
    public GameObject alienBig;

    private float timeBetweenEnemies = 2f;  
    private int secondsBeforeFirstEnemyAppears = 1; 

    private float timeLastAlien;

    void FixedUpdate () {

        if (Time.realtimeSinceStartup > secondsBeforeFirstEnemyAppears && Time.time >= timeLastAlien) {
            
            Instantiate(alien, new Vector3(Random.Range(-5f, 5f), 0, 10f), Quaternion.identity);
            Instantiate(alienBig, new Vector3(Random.Range(-5f, 5f), 0, 15f), Quaternion.identity);

            timeLastAlien = Time.time + timeBetweenEnemies;
        }
    }
}

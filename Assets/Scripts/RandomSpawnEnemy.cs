using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnEnemy : MonoBehaviour
{
 	public Transform[] spawnPoints;
	public GameObject[] enemyPrefabs;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateEnemy", 0, 5);
    }

    // Update is called once per frame
    void Update()
    {


       
    }

    void GenerateEnemy()
    {
        int RandomEnemy = Random.Range(0, enemyPrefabs.Length);
        int RandomSpawnPoint = Random.Range(0, spawnPoints.Length);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        Instantiate(enemyPrefabs[0], spawnPoints[RandomSpawnPoint].position, transform.rotation);
    }
}

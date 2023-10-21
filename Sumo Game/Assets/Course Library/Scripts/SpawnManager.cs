using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerup;
    private float spawnPosition = 9;
    public int enemyCount;
    private int enemyNumber = 1; //number enemies in wave
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        GenerateEnemies(enemyNumber);
        
    }

    // Update is called once per frame
    void Update()
    {
        //if no emenies present and game not instantiate enemy wave and increase number enemies each wave
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0 && playerControllerScript.gameOver == false)
        {
            Instantiate(powerup, GenerateSpawnPoint(), powerup.transform.rotation); //one powerup per wave
            enemyNumber += 1;
            GenerateEnemies(enemyNumber);
            Debug.Log("Enemy Wave " + enemyNumber); //tell player enemy wave
        }
    }

    void GenerateEnemies(int enemiesToSpawn)
    {
        //method instantiating wave
        for (int i = 0; i < enemiesToSpawn; i++)
            {
            Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
        }
        
    }

    private Vector3 GenerateSpawnPoint()
    {
        //generating and return random position
        float spawnX = Random.Range(-spawnPosition, spawnPosition);
        float spawnZ = Random.Range(-spawnPosition, spawnPosition);
        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);
        return randomPos;
    }
}

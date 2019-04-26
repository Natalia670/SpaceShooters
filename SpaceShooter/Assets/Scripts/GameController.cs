using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject fleet;
    public Vector3 spawnValues;
    public float spawnAsteroidsWait;
    public float spawnEnemiesWait;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnEnemies());
       
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
           
            Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
            Instantiate(hazard, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnAsteroidsWait);
        }

        
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnEnemiesWait);
            Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
            Instantiate(fleet, spawnPosition, Quaternion.identity);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}

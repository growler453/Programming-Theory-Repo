using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> candyPrefabs;
    private float spawnRange = 10.0f;
    private bool spawning;

    void Update()
    {
        if (GameManager.gameActive && !spawning)
        {
            StartCoroutine(SpawnCandy());
            spawning = true;
        } 
        else if (!GameManager.gameActive && spawning)
        {
            spawning = false;
        }
    }

    IEnumerator SpawnCandy()
    {
        yield return new WaitForSeconds(1);
        transform.position = new Vector3(Random.Range(-spawnRange, spawnRange), transform.position.y, Random.Range(-spawnRange, spawnRange));
        Instantiate(candyPrefabs[Random.Range(0, candyPrefabs.Count)], transform.position, transform.rotation);
        if(spawning) StartCoroutine(SpawnCandy());
    }
}

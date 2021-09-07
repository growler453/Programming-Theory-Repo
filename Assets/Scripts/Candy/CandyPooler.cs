using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyPooler : MonoBehaviour
{
    [SerializeField] List<GameObject> pooledObjects;
    private GameObject currentObject;
    private float spawnRange = 10.0f;

    void Start()
    {
        StartCoroutine("SpawnCandy");
    }

    IEnumerator SpawnCandy()
    {
        yield return new WaitForSeconds(1);
        currentObject = GetPooledObject();
        if (currentObject != null)
        {
            currentObject.SetActive(true);
            currentObject.transform.position = 
                new Vector3(Random.Range(-spawnRange, spawnRange), transform.position.y, Random.Range(-spawnRange, spawnRange));
            DespawnCandy(currentObject);
        }
        SpawnCandy();
    }

    IEnumerator DespawnCandy(GameObject activeObject)
    {
        yield return new WaitForSeconds(5);
        activeObject.SetActive(false);
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        } 
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSpawner : MonoBehaviour
{
    public int leavesToSpawn;
    public GameObject leafPrefab;
    public int maxX;
    public int minX;
    public int maxY;
    public int minY;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < leavesToSpawn; i++)
        {
            spawnObject();
        }
    }

    void spawnObject()
    {
        GameObject newLeaf =  Instantiate(leafPrefab, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0), Quaternion.identity);
        newLeaf.transform.parent = gameObject.transform;
    }   // function to Instantiate leaves of random location
}
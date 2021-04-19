using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;

    public int counter = 0;
    public int stopSpawn = 10;

    public float spawnRate = 2f;
    float nextSpawn = 0f;
    int whatToSpawn;

    public Vector3 center;
    public Vector3 size;

    public Quaternion min;

    // Start is called before the first frame update
    void Start()
    {
        SpawnItem();
    }

    // Update is called once per frame
    void Update()
    {
        
        while(counter < stopSpawn)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            whatToSpawn = Random.Range(1, 7);
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(prefab1, pos, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(prefab2, pos, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(prefab3, pos, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(prefab4, pos, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(prefab5, pos, Quaternion.identity);
                    break;
                case 6:
                    Instantiate(prefab6, pos, Quaternion.identity);
                    break;

            }
            counter++;
        }
        
    }

    public void SpawnItem()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(prefab1, pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}

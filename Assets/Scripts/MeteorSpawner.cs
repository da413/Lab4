using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public GameObject bigMeteorPrefab;
    public float repeatingSpawnTime = 2f;
    public float initSpawnTime = 1f;
    public int meteorCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMeteor", initSpawnTime, repeatingSpawnTime);
    }

    private void SpawnMeteor()
    {
        Instantiate(meteorPrefab, new Vector3(Random.Range(-5, 5), 7.5f, 0), Quaternion.identity);
        meteorCount++;

        if (meteorCount % 5 == 0)
        {
            SpawnBigMeteor();
        }
    }

    private void SpawnBigMeteor()
    {
        Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-5, 5), 7.5f, 0), Quaternion.identity);
    }

    public void RegisterMeteorDestroyed()
    {
        meteorCount--;
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }
}

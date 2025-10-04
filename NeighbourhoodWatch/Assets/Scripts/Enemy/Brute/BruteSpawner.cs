using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject brutePrefab;

    public float spawnInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBrute());
    }

    IEnumerator SpawnBrute()
    {
        while (true)
        {
            Instantiate(brutePrefab, spawnPoint.position, transform.rotation);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
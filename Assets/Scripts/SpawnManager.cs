using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] projectilePrefabs;
    public GameObject spawnPoint;
    public float leftBound = -2.5f, rightBound = 1.8f;
    public float spawnDelay;
    private bool spawning = true;


    private void Awake()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
    }
    void Start()
    {
       
        StartCoroutine(SpawnRandomFruit());
        spawning = true;
    }


    void Update()
    {
        if (GameManager.Instance.GameOver)
        {
            StopAllCoroutines();
            spawning = false;
         //TODO Find another way to do this.
        }else if(GameManager.Instance.GameOver == false && spawning == false)
        {
            StartCoroutine(SpawnRandomFruit());
            spawning = true;
        }
    }

    IEnumerator SpawnRandomFruit()
    {
        yield return new WaitForSeconds(spawnDelay);
       
        float randomX = Random.Range(leftBound, rightBound);
        int randomChoice = Random.Range(0, projectilePrefabs.Length);
        Vector3 spawnPosition = spawnPoint.transform.position;
        spawnPosition.x = randomX;
        Instantiate(projectilePrefabs[randomChoice], spawnPosition, transform.rotation);
        StartCoroutine(SpawnRandomFruit());
    }

   
}

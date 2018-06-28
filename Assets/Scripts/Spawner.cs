using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject obstacles;
    public Transform obsSpawn;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnObstacles());
    }

    // Update is called once per frame
    IEnumerator SpawnObstacles()
    {
        while (!GameControllerBehaviour.gameOver)
        {
            float randomTime = Random.Range(1.0f, 2.5f);
            yield return new WaitForSeconds(randomTime);
            Instantiate(obstacles, obsSpawn.position, Quaternion.identity);
        }
        
    }
}

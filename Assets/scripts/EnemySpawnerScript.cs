using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    public GameObject enemy;
    float randX;
    float randY;
    Vector2 whereToSpawn;

    public float xRangeMax;
    public float xRangeMin;

    public float yRangeMax;
    public float yRangeMin;

    public float spawnRate = 2f;
    float nextSpawn = 0.0f;


    void Start()
    {
        
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-xRangeMin, xRangeMax);
            randY = Random.Range(-yRangeMin, yRangeMax);
            whereToSpawn = new Vector2(randX + transform.position.x, randY + transform.position.y);
            Instantiate (enemy, whereToSpawn, Quaternion.identity);
        }
    }
}

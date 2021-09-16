using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform enemy;
    private GameObject levelLoader;
    private Vector2 movement;
    public float moveSpeed;
    public int health = 100;


    void Start()
    {
    
    }
    void Update()
    {
        Vector3 direction = enemy.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

           if (health <= 0)
           {
                StartCoroutine(DieSlow()); // Coroutine can be paused for a slower death
           }
    }

    IEnumerator DieSlow()
    {
        yield return new WaitForSeconds(0.2f); //waits 0,2 secs
        Destroy(gameObject);
        levelLoader = GameObject.FindGameObjectWithTag("LevelLoader"); 
        levelLoader.GetComponent<LevelLoader>().gameScore += 100; // adds score
    }
     
}

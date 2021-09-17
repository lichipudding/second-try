using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform enemy;
    private GameObject gameManager;
    private Vector2 movement;
    public float moveSpeed;
    public int health = 100;



    public void TakeDamage(int damage)
    {
        health -= damage;

           if (health <= 0)
           {
                StartCoroutine(DieSlow()); // Coroutine used to delay DieSlow()
           }
    }

    IEnumerator DieSlow()
    {
        yield return new WaitForSeconds(0.2f); // waits on this line for 0.2 sec
        Destroy(gameObject);
        gameManager = GameObject.FindGameObjectWithTag("GameManager"); 
        gameManager.GetComponent<GameManager>().gameScore += 100; // adds score
    }
     
}

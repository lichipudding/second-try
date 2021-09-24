using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform enemy;
    private GameObject gameManager;
    private Vector2 movement;
    public float moveSpeed;
    public int health = 100;
    private int scoreAdd = 50;
    private Controller ScoreController; 



    private void Start()
    {
        ScoreController = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<Controller>();
       
        
    }
    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play("EnemyHit");

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
        FindObjectOfType<AudioManager>().Play("ScoreUp");
        ScoreController.AddScore(scoreAdd); 
        gameManager = GameObject.FindGameObjectWithTag("GameManager"); 
        gameManager.GetComponent<GameManager>().gameScore += scoreAdd; // adds score
    }

    
}

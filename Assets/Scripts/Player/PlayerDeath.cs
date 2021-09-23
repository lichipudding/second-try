using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private GameObject gameManager;
    public string killerTag = "Enemy";
    public int playerHealth = 3;
    public Transform playerPosition;
    public Vector2 checkPointPosition;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void ChangeHealth(int health)
    {
        playerHealth += health; 
        if (playerHealth ==0)
        {
            StartCoroutine(DieSlow()); // Coroutine used to delay DieSlow()
        }
        Debug.Log(playerHealth);
    }

       void DamagePlayer(int health)
    {
        ChangeHealth(-(health));
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(killerTag)) // Kill the player if enemy touches object with this script
        {
            DamagePlayer(1);
            gameObject.transform.position = checkPointPosition;
            Destroy(other.gameObject);
            GameObject.Find("GameManager").GetComponent<LifeCount>().LoseLife();
        }
    }

    IEnumerator DieSlow()
    {
        yield return new WaitForSeconds(0.2f); // waits on this line for 0.2 sec
        Destroy(gameObject);
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager.GetComponent<GameManager>().playerIsDead = true;
    }



}

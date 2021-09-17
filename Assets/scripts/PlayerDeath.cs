using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private GameObject gameManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) // Kill the player if it touches an enemy
        {
            StartCoroutine(DieSlow()); // Coroutine used to delay DieSlow()
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage = 50; //how much damage the bullet is doing
    public Rigidbody2D rb;
    public float bulletRicochet = 0.8f; // for how long the bullet lives after hitting an enemy

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

   
    void OnTriggerEnter2D(Collider2D hitInfo) // bullet damages enemy
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            IEnumerator bulletKiller() // Quick function to delay the bullets death
            {
                yield return new WaitForSeconds(bulletRicochet); // bullet delay
                Destroy(gameObject);
            }
            StartCoroutine(bulletKiller());
        }
    }

}
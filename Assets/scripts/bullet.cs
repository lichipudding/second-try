using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage = 50; //how much damage the bullet is doing
    public Rigidbody2D rb;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }
    private void OnCollisionEnter2D(Collision2D collision) //destroy bullet on collision
    {
        if (collision.gameObject.CompareTag("Enemy"))
          {
              Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collider2D hitInfo) // bullet damages enemy
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
        }

        Destroy(gameObject);
    }

}

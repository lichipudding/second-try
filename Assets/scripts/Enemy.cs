using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform enemy;
    
    private Vector2 movement;
    public float moveSpeed;

    public int health = 100;
    public Rigidbody2D rb;
    public GameObject death;
   
    public void takeDamage (int damage)
    {
        health -= damage; 

        if (health <= 0)
        {
            Die();
        }
    }

   
    void Start()
    {
        enemy = this.GetComponent<Transform>();
     rb = this.GetComponent < Rigidbody2D > ();
    }

    void Update()
    {
        Vector3 direction = enemy.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
    rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void Die()
    {

        Destroy(gameObject);
    }
}

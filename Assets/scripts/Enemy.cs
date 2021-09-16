using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D thisRigidbody;
    private Vector2 movement;
    public float moveSpeed;

    void Start()
    {
        thisRigidbody = this.GetComponent < Rigidbody2D > ();
        player = 

    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        thisRigidbody.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        thisRigidbody.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

}

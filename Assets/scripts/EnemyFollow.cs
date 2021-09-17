using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private GameObject gameManager;
    private IEnumerator enemy;
    private bool isPlayerDead;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 1f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("PlayerCharacter").transform;
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        isPlayerDead = gameManager.GetComponent<GameManager>().playerIsDead;
    }

    void Update()
    {
        if (player == null) // Kills all following enemies if player dies
        {
            return;
        }

        Vector3 direction = player.position - transform.position;
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

    IEnumerator DieSlow()
    {
        yield return new WaitForSeconds(0.2f); // waits on this line for 0.2 sec
        Destroy(gameObject);
    }


}
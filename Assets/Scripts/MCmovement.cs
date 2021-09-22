using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCmovement : MonoBehaviour
{
    public float mSpeed = 4f;
    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;
    public GameObject player;

    Vector2 movement;
    Vector2 mPos;

    private void Start()
    {
        GetComponent<GameObject>();
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("speed", Mathf.Abs(movement.y));

        mPos = cam.ScreenToWorldPoint(Input.mousePosition);
               movement = movement.normalized;

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * mSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle; 
    }
}

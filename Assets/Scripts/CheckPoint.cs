using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("PlayerCharacter"))
        {
            Debug.Log("collision");
            gameObject.transform.position = GameObject.FindGameObjectWithTag("PlayerCharacter").GetComponent<PlayerDeath>().checkPointPosition;

        }
    }
}

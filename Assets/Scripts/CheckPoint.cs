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
            GameObject.FindGameObjectWithTag("PlayerCharacter").GetComponent<PlayerDeath>().checkPointPosition = gameObject.transform.position;
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{

    public Transform playerFollow;

    private void FixedUpdate()
    {
        //transform.position = new Vector3(playerFollow.position.x, playerFollow.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, playerFollow.position.y, transform.position.z);


    }

}

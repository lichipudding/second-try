using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int remainingLives;
    public int playerHealth = 3;

    public void Life(int healthCount)
    {
        if (playerHealth--)
        {
            return;
        }


        //    health -= 1
        //  if (health<=0)
        //{
        //  Debug.Log("dead!");
        //}
    }

    private void LoseLife()
    {

        remainingLives--;
        lives[remainingLives].enabled = false;

        if (remainingLives==0)
        {
            Debug.Log("YouLost!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            LoseLife();
    }
}

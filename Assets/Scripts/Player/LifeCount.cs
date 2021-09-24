using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;


    private void OnSceneWasChanged(Scene scene, LoadSceneMode mode) // runs when every scene loads
    {
        lives[0] = GameObject.Find("Life").GetComponent<Image>();
        lives[1] = GameObject.Find("Life_2").GetComponent<Image>();
        lives[2] = GameObject.Find("Life_3").GetComponent<Image>();
    }

    public void LoseLife()
    {
        FindObjectOfType<AudioManager>().Play("LoseLife");
        if (livesRemaining == 0)
            return;

        livesRemaining--;

        lives[livesRemaining].enabled = false;
    }

    private void Update()
    {
        if (lives.Length < livesRemaining)
        {
            lives[livesRemaining].enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("trying to lose life");
            LoseLife();
        }
            
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneWasChanged; // subscribes 
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneWasChanged;
    }
}

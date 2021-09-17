using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject levelLoader;

    [HideInInspector]
    public int gameScore;
    bool scoreQuotaMet = false;
    public int scoreQuota;
  
    void Start()
    {

    }

    private void OnSceneWasChanged (Scene scene, LoadSceneMode mode) // runs when every scene loads
    {
        scoreQuotaMet = false;
        levelLoader = GameObject.FindGameObjectWithTag("LevelLoader");
        scoreQuota = levelLoader.GetComponent<LevelLoader>().levelQuota;
        Debug.Log("Scene was loaded");
    }

    void Update()
    {
        Debug.Log(gameScore);

        if (gameScore >= scoreQuota)
        {
            scoreQuotaMet = true;
        }

        //  else { scoreQuotaMet = false; }

        if (scoreQuotaMet == true)
        {
            levelLoader = GameObject.FindGameObjectWithTag("LevelLoader");
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel(); 
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            levelLoader = GameObject.FindGameObjectWithTag("LevelLoader");
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel();
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

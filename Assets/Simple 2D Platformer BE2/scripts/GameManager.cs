using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject levelLoader;

    [HideInInspector]
    private GameObject ScoreController;
    public int gameScore;
    private int savedGameScore;
    bool scoreQuotaMet = false;
    [HideInInspector]
    public bool playerIsDead = false;
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
       

        if (gameScore >= scoreQuota)
        {
            scoreQuotaMet = true;
        }

        //  else { scoreQuotaMet = false; }

        if (scoreQuotaMet == true)
        {
            levelLoader = GameObject.FindGameObjectWithTag("LevelLoader");
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel();
            savedGameScore = gameScore;  // Saves gamescore when loading next level
            Debug.Log("saving gamescore, saved score is" + savedGameScore);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            levelLoader = GameObject.FindGameObjectWithTag("LevelLoader");
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel();
            savedGameScore = gameScore;  // Saves gamescore when loading next level
            Debug.Log("saving gamescore, saved score is" + savedGameScore);
        }

        if (playerIsDead == true)
        {
            levelLoader = GameObject.FindGameObjectWithTag("LevelLoader");
            levelLoader.GetComponent<LevelLoader>().LoadCurrentLevel();
            gameScore = savedGameScore;            
            playerIsDead = false;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            levelLoader = GameObject.FindGameObjectWithTag("LevelLoader");
            levelLoader.GetComponent<LevelLoader>().LoadCurrentLevel();
            gameScore = savedGameScore;
            playerIsDead = false;
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

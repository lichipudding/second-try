using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject levelLoader;
    private GameObject WinEnabler;
    private GameObject LoseEnabler;



    [HideInInspector]
    private GameObject ScoreController;
    public int gameScore;
    private int savedGameScore;
    [HideInInspector]
    public bool scoreQuotaMet = false;
    [HideInInspector]
    public bool playerIsDead = false;
    private bool coroutineIsRunning = false;
    private bool gameIsPaused = false;
    public int scoreQuota;
  
    void Start()
    {

    }

    private void OnSceneWasChanged (Scene scene, LoadSceneMode mode) // runs when every scene loads
    {
        scoreQuotaMet = false;
        GetComponent<LifeCount>().livesRemaining = 3;
        levelLoader = GameObject.FindGameObjectWithTag("LevelLoader");
        scoreQuota = levelLoader.GetComponent<LevelLoader>().levelQuota;
        Debug.Log("Scene was loaded");
        StopAllCoroutines(); // keeps subsequent kills during secene load to load the scene again
        coroutineIsRunning = false;
    }

    public void LoadNextLevelCheck()
    {
        Debug.Log("Checking if score is enough");
        if (gameScore >= scoreQuota)
        {
            scoreQuotaMet = true;
        }

        else
        {
            scoreQuotaMet = false;
        }

        if (scoreQuotaMet)
        {
            if (coroutineIsRunning == false) // keeps the routine from running several times while waitforseconds

            {
                //coroutineReady = false;
                scoreQuotaMet = false;

                StartCoroutine(LoadNextLevelDelay()); // this gives time for congratulation tex
                WinEnabler = GameObject.FindGameObjectWithTag("WinMesseage");
                FindObjectOfType<AudioManager>().Play("LevelClear");
                WinEnabler.GetComponent<Enabler>().EnableThis();
            }

            Debug.Log("saving gamescore, saved score is " + savedGameScore);
            savedGameScore = gameScore;  // Saves gamescore when loading next level
        }

    }

    IEnumerator LoadNextLevelDelay()
    {
        coroutineIsRunning = true;
        Debug.Log("Starting LoadNextLevelDelay()");
        yield return new WaitForSeconds(5);
        levelLoader = GameObject.FindGameObjectWithTag("LevelLoader");
        levelLoader.GetComponent<LevelLoader>().LoadNextLevel();
        // coroutineReady = true;
        coroutineIsRunning = false;
    }

    IEnumerator LoadCurrentLevelDelay()
    {
        coroutineIsRunning = true;
        Debug.Log("Starting LoadCurrentLevelDelay()");
        yield return new WaitForSeconds(5);
        levelLoader = GameObject.FindGameObjectWithTag("LevelLoader");
        levelLoader.GetComponent<LevelLoader>().LoadCurrentLevel();
        // coroutineReady = true;
        coroutineIsRunning = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        { if (gameIsPaused == false)
            {
                PauseGame();
            }
         else
            {
                ResumeGame();
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            levelLoader = GameObject.FindGameObjectWithTag("LevelLoader");
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel();
            savedGameScore = gameScore;  // Saves gamescore when loading next level
            Debug.Log("saving gamescore, saved score is" + savedGameScore);
        }

        if (playerIsDead == true)
        {
            StartCoroutine(LoadCurrentLevelDelay());
            LoseEnabler = GameObject.FindGameObjectWithTag("LoseMesseage");
            LoseEnabler.GetComponent<Enabler>().EnableThis();
            FindObjectOfType<AudioManager>().Play("GameOver");
            gameScore = savedGameScore;            
            playerIsDead = false;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(LoadCurrentLevelDelay());
            gameScore = savedGameScore;
            playerIsDead = false;
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
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

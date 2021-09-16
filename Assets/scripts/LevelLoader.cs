using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [HideInInspector]
    public int gameScore;
    public int scoreQuota = 1000;
    bool scoreQuotaMet = false;
    public Animator transition;
    public float transitionTime = 1f;

    void Start()
    {
        scoreQuotaMet = false; 
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
            LoadNextLevel();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1))

        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
       
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }


}

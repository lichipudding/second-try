using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [HideInInspector]
    public int enemyKillCount;
    public int killQuota = 10;
    bool killQuotaMet = false;
    public Animator transition;
    public float transitionTime = 1f;

    void Start()
    {
        killQuotaMet = false; 
    }





    void Update()
    {
        if (enemyKillCount >= killQuota)
        {
            killQuotaMet = true;
        }

      //  else { killQuotaMet = false; }

        if (killQuotaMet == true)
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

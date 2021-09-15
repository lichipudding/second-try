using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    int enemyCount;
    bool killQuotaMet;
    public Animator transition;
    public float transitionTime = 1f;

    void Start()
    {
        
    }





    void Update()
    {
        if (Input.GetButton("Fire1"))
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

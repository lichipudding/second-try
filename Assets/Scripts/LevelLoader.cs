using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int levelQuota = 250;
    public Animator transition;
    public float transitionTime = 1f;

    void Start()
    {
        Debug.Log(levelQuota);
    }

    void Update()
    {
       
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

    public void LoadCurrentLevel() 
    {
        StartCoroutine(LoadCurrentLevel(SceneManager.GetActiveScene().buildIndex));

    }

    IEnumerator LoadCurrentLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

}

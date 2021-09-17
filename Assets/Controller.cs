using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{
    public int currentScore = 0;
    public GameObject gameManager;

    [SerializeField] private TextMeshProUGUI highScore;

  
   private void Start()
    {
        highScore = highScore.GetComponent<TextMeshProUGUI>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        
        currentScore = 0;
        UpdateScore();
    }

   public void AddScore(int amount)
    {
        Debug.Log("adding score");
        currentScore = gameManager.GetComponent<GameManager>().gameScore;
        currentScore += amount;
        UpdateScore();
    }
       
    private void UpdateScore()
    {
       highScore.text = currentScore.ToString("0");
    }
}

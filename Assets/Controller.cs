using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{
    public int currentScore = 0;

    [SerializeField] private TextMeshProUGUI highScore;

  
   private void Start()
    {
        highScore = highScore.GetComponent<TextMeshProUGUI>();
        currentScore = 0;
        UpdateScore();
    }

   public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScore();
    }
       
    private void UpdateScore()
    {
       highScore.text = currentScore.ToString("0");
    }
}

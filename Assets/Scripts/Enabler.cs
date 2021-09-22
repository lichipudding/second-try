using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enabler : MonoBehaviour
{
    public TextMeshProUGUI textToEnable;

    void Start()
    {
        textToEnable = gameObject.GetComponent<TextMeshProUGUI>();
        textToEnable.enabled = false;
    }

    public void EnableThis() // enables object with this script
    {
        textToEnable.enabled = true;
    }



    void Update()
    {
        
    }
}

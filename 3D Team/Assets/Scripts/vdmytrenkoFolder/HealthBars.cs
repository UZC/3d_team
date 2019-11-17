using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    [SerializeField]
    Image player1;
    [SerializeField]
    Image player2;

    [SerializeField]
    Health healthOfPlayer1;
    [SerializeField]
    Health healthOfPlayer2;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        player1.fillAmount = (float)healthOfPlayer1.GetHealth() / 100;
        player2.fillAmount = (float)healthOfPlayer2.GetHealth() / 100;
    }
}

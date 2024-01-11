using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieClickerGame : MonoBehaviour
{
    
    

    private int score;
    private int Highscore;

    [SerializeField] private int cookieAmount = 3;

    void Start()
    {
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score);
    }

    public void AddScore() 
    {
        score += cookieAmount;
    }

    private void UpdateScore()
    {
        Debug.Log("Score: " + score);
    }

}

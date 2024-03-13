using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverTxt;
    [SerializeField] private TextMeshProUGUI gameOverSubTxt;

    [SerializeField] private TextMeshProUGUI gameWinTxt;
    [SerializeField] private TextMeshProUGUI gameWinSubTxt;
    // Start is called before the first frame update
    void Start()
    {
        gameOverTxt.enabled = false;
        gameOverSubTxt.enabled = false;
        gameWinTxt.enabled = false;
        gameWinSubTxt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerCaught()
    {
        gameOverTxt.enabled = true;
        gameOverSubTxt.enabled = true;
        Time.timeScale = 0;
    }
    public void PlayerWin()
    {
        gameWinTxt.enabled = true;
        gameWinSubTxt.enabled = true;
        Time.timeScale = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCollider : MonoBehaviour
{
    private GameObject _playerOne;
    private GameObject _playerTwo;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _playerOne = GameObject.FindGameObjectWithTag("Player");
        _playerTwo = GameObject.FindGameObjectWithTag("Player2");

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("player1 has died");
        }
        else if (collision.CompareTag("Player2"))
        {
            Debug.Log("player2 has died");
        }

        if (collision.CompareTag("Player") || collision.CompareTag("Player2"))
        {
            //teleport players
            
            _playerOne.transform.position = gameManager.lastCheakPointPos;
            _playerTwo.transform.position = gameManager.lastCheakPointPos;

        }

        
    }
}

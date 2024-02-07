using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollider : MonoBehaviour
{
    private bool _playerOneEnd = false;
    private bool _playerTwoEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerOneEnd = true;
            Debug.Log("player1 entered win col");
        }
        else if (collision.CompareTag("Player2"))
        {
            _playerTwoEnd = true;
            Debug.Log("player2 entered win col");
        }

        if (_playerOneEnd && _playerTwoEnd)
        {
            Debug.Log("WIN");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerOneEnd = false;
            Debug.Log("player1 exited win col");
        }
        else if (collision.CompareTag("Player2"))
        {
            _playerTwoEnd = false;
            Debug.Log("player2 exited win col");
        }
    }
}

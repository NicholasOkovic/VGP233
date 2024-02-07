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
        }
        else if (collision.CompareTag("Player2"))
        {
            _playerTwoEnd = true;
        }

        if (_playerOneEnd && _playerTwoEnd)
        {
            Debug.Log("WIN");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
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
        Destroy(collision.gameObject);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("player1 has died");
        }
        else if (collision.CompareTag("Player2"))
        {
            Debug.Log("player2 has died");
        }
    }
}

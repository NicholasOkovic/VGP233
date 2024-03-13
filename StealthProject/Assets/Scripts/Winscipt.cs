using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winscipt : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            GameManager.FindObjectOfType<GameManager>().PlayerWin();
        }
    }
}

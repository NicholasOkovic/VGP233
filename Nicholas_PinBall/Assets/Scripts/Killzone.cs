using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Killzone : MonoBehaviour
{
    [SerializeField] private int _points;
    [SerializeField] private GameObject _pointManager;

    //Points pointsController;

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
        _pointManager.GetComponent<Points>()._score += _points;
        Destroy(collision.gameObject);
    }
}

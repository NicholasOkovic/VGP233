using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour
{
    [SerializeField] private float _startPosX;
    [SerializeField] private float _endPosX;
    private Rigidbody rb;



    [SerializeField] private float _speed;


    private float _timer;
    [SerializeField] private float _cooldown = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        rb.MovePosition(new Vector3(transform.position.x + Time.deltaTime * _speed, transform.position.y, transform.position.z));
        if ((transform.position.x < _endPosX || transform.position.x > _startPosX) && _timer <= 0)
        {
            _speed *= -1;
            _timer = _cooldown;
        }

        //if (transform.position.x < _endPosX || transform.position.x > _startPosX)
        //{
        //    _speed *= -1;

        //    //rb.MovePosition(new Vector3(transform.position.x - Time.deltaTime * 10, transform.position.y, transform.position.z));

        //    //rb.velocity.Set(-10, 0, 0);
        //}
        //else if (transform.position.x < _startPosX)
        //{
        //    //rb.MovePosition(new Vector3(transform.position.x + Time.deltaTime * 10, transform.position.y, transform.position.z));

        //    //rb.velocity.Set(10, 0, 0);
        //}
    }
}

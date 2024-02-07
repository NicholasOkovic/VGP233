using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _crouchSpeed;
    [SerializeField] float _jumpForce;
    private bool _grounded = false;
    private bool _crouched = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxisRaw("HorizontalArrow") * Time.deltaTime;

        if (_crouched)
            transform.Translate(horizontalMove * _crouchSpeed, 0, 0);
        else
            transform.Translate(horizontalMove * _moveSpeed, 0, 0);

        if (Input.GetKey(KeyCode.DownArrow) && _grounded)
        {
            Debug.Log("crounching");
            if(!_crouched)
            _crouched = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Debug.Log("no longer crounching");
            _crouched = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && _grounded)
        {
            if(_crouched)
                rb.AddForce(new Vector2(0, _jumpForce*2));
            else
                rb.AddForce(new Vector2(0, _jumpForce));
        }
        //else if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        //{
        //    rb.AddForce(new Vector2(0, _jumpForce));
        //   // _grounded = false;
        //}



        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("do somehting special for p1");
        }


    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.tag == "Platforms")
    //    {
    //        _grounded = true;
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platforms")
        {
            _grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platforms")
        {
            _grounded = false;
            _crouched = false;
        }
    }
}

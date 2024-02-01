using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _jumpForce;
    private bool _grounded = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal") * _moveSpeed;

        transform.Translate(horizontalMove * Time.deltaTime, 0, 0);


        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            rb.AddForce(new Vector2(0, _jumpForce));
           // _grounded = false;
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
        }
    }
}

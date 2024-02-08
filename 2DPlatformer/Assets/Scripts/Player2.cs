using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _crouchSpeed;
    [SerializeField] float _jumpForce;
    private bool _grounded = false;
    private bool _crouched = false;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalMove = Input.GetAxisRaw("HorizontalAD");

        animator.SetInteger("runSpeed", (int)horizontalMove);

        if (_crouched)
            transform.Translate(horizontalMove * _crouchSpeed * Time.deltaTime, 0, 0);
        else
            transform.Translate(horizontalMove * _moveSpeed * Time.deltaTime, 0, 0);

        //animation
        if (horizontalMove < 0)
        {
            sprite.flipX = true;
        }
        else if (horizontalMove > 0)
        {
            sprite.flipX = false;
        }


        if (Input.GetKey(KeyCode.S) && _grounded)
        {
            Debug.Log("crounching");
            if (!_crouched)
                _crouched = true;
        }
        else if (Input.GetKeyUp(KeyCode.S) && _grounded)
        {
            Debug.Log("no longer crounching");
            _crouched = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && _grounded)
        {
            if (_crouched)
            {
                rb.AddForce(new Vector2(0, _jumpForce * 2));
                Debug.Log("no longer crounching");
            }
            else
                rb.AddForce(new Vector2(0, _jumpForce));
        }




        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("do somehting special for p2");
        }
    }
 
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

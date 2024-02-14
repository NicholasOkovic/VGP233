using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    public static float _jumpForce = 400;
    //private bool _grounded = false;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float _timer;
    [SerializeField] private float _cooldown;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (_timer > 0)
        //{
        //    _timer -= Time.deltaTime;
        //}
        //movement
        float horizontalMove = Input.GetAxisRaw("Horizontal");

       

        animator.SetInteger("runSpeed", (int)horizontalMove);


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



        //abilities(inc jump)

        if (Input.GetKeyDown(KeyCode.W) && animator.GetBool("grounded"))
        {
            rb.AddForce(new Vector2(0, _jumpForce));
        }

        //if (Input.GetKeyDown(KeyCode.Space) && _timer <= 0)
        //{
        //    Debug.Log("do somehting special for p1");
        //    _timer = _cooldown;
        //    transform.localScale = new Vector3(1, transform.localScale.y * -1, 1);
        //    _jumpForce *= -1;
  
        //    rb.gravityScale *= -1;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platforms" || collision.gameObject.tag == "Player" )
        {
            animator.SetBool("grounded", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platforms" || collision.gameObject.tag == "Player")
        {
            animator.SetBool("grounded", false);
        }
    }
}

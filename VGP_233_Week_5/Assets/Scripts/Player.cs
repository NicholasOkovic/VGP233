using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Animator animator;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirection = Input.GetAxisRaw("Horizontal");

        animator.SetInteger("WalkSpeed", (int)moveDirection);

        transform.Translate(moveDirection * _moveSpeed * Time.deltaTime, 0, 0);

        if (moveDirection < 0)
        {
            sprite.flipX = true;
        }
        else if (moveDirection > 0)
        {
            sprite.flipX = false;
        }
    }
}
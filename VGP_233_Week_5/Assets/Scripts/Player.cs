using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirection = Input.GetAxisRaw("Horizontal");

        animator.SetInteger("WalkSpeed", (int)moveDirection);

        transform.Translate(moveDirection * _moveSpeed * Time.deltaTime, 0, 0);
    }
}

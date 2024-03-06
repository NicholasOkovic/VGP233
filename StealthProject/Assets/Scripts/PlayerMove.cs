using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float MovementSpeed;

    [SerializeField] private Transform orientation;

    [SerializeField] private float groundDrag;

    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask whatIsGround;
    bool grounded;


    float xMovement = 0;
    float zMovement = 0;

    //private float _timer;
    //[SerializeField] private float _cooldown = 0.5f;

    Vector3 moveDirection;

    private Rigidbody rb;

    // Start is called before the first frame update

   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        //if (_timer > 0)
        //{
        //    _timer -= Time.deltaTime;
        //}
        xMovement = Input.GetAxis("Horizontal");
        zMovement = Input.GetAxis("Vertical");

       

        //Vector3 moveInput = new Vector3(xMovement, 0, zMovement).normalized;
        //rb.MovePosition(transform.position + (moveInput.normalized * Time.fixedDeltaTime * MovementSpeed));


        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > MovementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * MovementSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

        

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
     
    }
    private void FixedUpdate()
    {
        moveDirection = orientation.forward * zMovement + orientation.right * xMovement;
        rb.AddForce(moveDirection.normalized * MovementSpeed * 10f, ForceMode.Force);
    }


}

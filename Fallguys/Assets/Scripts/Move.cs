using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Move : MonoBehaviour
{
 
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float JumpSpeed;
    private float turnSmoothVelocity;
    [SerializeField] private Transform cam;
    [SerializeField] private float turnSmoothTime = 0.2f;

    private Rigidbody rb;

    private bool _grounded;
    public float playerHeight;
    public LayerMask Platform;

    float xMovement = 0;
    float zMovement = 0;

    private float _timer;
    [SerializeField]private float _cooldown = 0.5f;


    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }


        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3(xMovement, 0, zMovement).normalized;

      
        float targetAngle = Mathf.Atan2(moveInput.x, moveInput.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        Vector3 moveDire = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


        if (Input.GetKeyDown(KeyCode.Mouse1) && _grounded == false)
        {
            rb.AddForce(new Vector3(JumpSpeed * moveDire.x, JumpSpeed/2, JumpSpeed * moveDire.z));

        }
        if (Input.GetKeyDown(KeyCode.Space) && _grounded == true && _timer <= 0)
        {
            rb.AddForce(new Vector3(0, JumpSpeed, 0));
            _timer = _cooldown;
        }

    }

    private void FixedUpdate()
    {
        if (_grounded)
        {
             xMovement = Input.GetAxis("Horizontal");
             zMovement = Input.GetAxis("Vertical");
        }
        
        Vector3 moveInput = new Vector3(xMovement, 0, zMovement).normalized;

        if (moveInput.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveInput.x, moveInput.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(transform.position + moveDir.normalized * Time.fixedDeltaTime * MovementSpeed);
        }
        //_grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, Platform);
        _grounded = Physics.BoxCast(transform.position + new Vector3(0,0.6f,0), transform.lossyScale, Vector3.down, transform.rotation, playerHeight, Platform);
       




        // rb.velocity = moveInput;

    }
   
    //private void OnTriggerExit(Collider collision)
    //{
    //    if (collision.gameObject.CompareTag("Platform"))
    //    {
    //        _grounded = false;
    //    }
    //}
    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.CompareTag("Platform"))
    //    {
    //        _grounded = true;
    //    }
    //}

}
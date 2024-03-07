using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float MovementSpeed;

    [SerializeField] private float throwSpeed;
    [SerializeField] private float throwHeight;

    [SerializeField] private Transform orientation;

    [SerializeField] private float groundDrag;

    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask whatIsGround;
    bool grounded;

    [SerializeField] private Light playerFLight;
    [SerializeField] private GameObject _rockPrefab;
    [SerializeField] private Transform _rockThrowPos;

    float xMovement = 0;
    float zMovement = 0;

    //private float _timer;
    //[SerializeField] private float _cooldown = 0.5f;

    Vector3 moveDirection;
    Vector3 throwDirection;

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
        //inputs

        if (Input.GetKeyDown(KeyCode.F))
        {
            playerFLight.enabled = !playerFLight.enabled;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("throw rock");
            
            GameObject rock = Instantiate(_rockPrefab, new Vector3(_rockThrowPos.position.x, _rockThrowPos.position.y, _rockThrowPos.position.z), Quaternion.identity);
            //Rigidbody rockRB = rock.GetComponent<Rigidbody>();

           

            throwDirection = orientation.forward;
            rock.GetComponent<Rigidbody>().AddForce(throwDirection.x * throwSpeed * 10, throwHeight, throwDirection.z * throwSpeed * 10, ForceMode.Force);
        }
     
    }
    private void FixedUpdate()
    {
        moveDirection = orientation.forward * zMovement + orientation.right * xMovement;
        rb.AddForce(moveDirection.normalized * MovementSpeed * 10f, ForceMode.Force);
    }


}

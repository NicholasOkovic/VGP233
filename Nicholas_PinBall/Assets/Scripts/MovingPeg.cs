using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPeg : MonoBehaviour
{

    [SerializeField] private int moveSpeed;

    [SerializeField] private float leftPos;
    [SerializeField] private float rightPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > rightPos || transform.position.x < leftPos) 
        { 
            moveSpeed *= -1;
        }

        transform.Translate(moveSpeed * Time.deltaTime, 0, 0, Space.World);
    }
}

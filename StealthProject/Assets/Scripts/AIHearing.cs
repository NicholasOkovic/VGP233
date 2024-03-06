using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIHearing : MonoBehaviour
{
    [SerializeField] private AIMove aiMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            RaycastHit hit;
            Physics.Linecast(aiMove.transform.position, other.transform.position, out hit);
            
            Debug.DrawLine(aiMove.transform.position, hit.point, Color.magenta, 2);
            
            aiMove.HeardSomething(other.transform);
           
        }


    }
}

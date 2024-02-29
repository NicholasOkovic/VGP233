using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISight : MonoBehaviour
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
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RaycastHit hit;
            if (Physics.Linecast(aiMove.transform.position, other.transform.position, out hit))
            {
                Debug.DrawLine(aiMove.transform.position, hit.point, Color.green, 2);
                if (hit.transform.CompareTag("Player"))
                {
                    aiMove.FoundPlayer(other.transform);
                }
                Debug.Log(hit.transform.name);
               
            }
        }
        

    }

}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private GameObject _rightFlipper;
    [SerializeField] private GameObject _leftFlipper;

    bool _resetFlipper = false;
    bool _activeFlipper = false;

   
    void Start()
    {
        //_minRotation = _rightFlipper.transform.rotation;
       
    }

   
    void Update()                                                                       ////ignore left for now, only focus right
    {
        if (_resetFlipper && !_activeFlipper) 
        {
            
            ResetFlipper(_rightFlipper);
        }

       if (_activeFlipper)
       {

            RotateFlipper(_rightFlipper);
            if (_rightFlipper.transform.localRotation.z <= -0.50)
            {
                _activeFlipper = false;
  
                _resetFlipper = true;
            }
 
       }


       if (Input.GetKeyDown(KeyCode.RightArrow))
       {
            _activeFlipper = true;
           
       }
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    _leftFlipper.transform.Rotate(0, 0, 50);
        //    Debug.Log("test");
        //}
    }


    private void RotateFlipper(GameObject flipper)
    {
        //check if rotation is above maxrot
        flipper.transform.Rotate(0, 0, -1);
        Debug.Log(flipper.transform.rotation.z);




    }
    private void ResetFlipper(GameObject flipper)
    {
        //constant rotate down
        if (flipper.transform.localRotation.z < 0)
        {
            flipper.transform.Rotate(0, 0, 0.5f);
            Debug.Log(flipper.transform.rotation.z);

        }
        else
        {
            _resetFlipper =false;
        }
       
    }

    //private void ActivateFlipper(GameObject flipper)
    //{
    //    _activeFlipper = true;

    //    RotateFlipper(flipper);


    //}

}

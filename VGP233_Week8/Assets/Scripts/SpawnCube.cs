using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    [SerializeField] private float RayTime;
    [SerializeField] private float RayLength;

    [SerializeField] private GameObject _cubeToSpawn;

    [SerializeField] private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {


        UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
        bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * RayLength, Color.red, RayTime);

        bool raycast = Physics.Raycast(ray, out hit, RayLength, layerMask);

        Debug.Log(hit.transform.name);



        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    RaycastHit hit;
        //    Debug.DrawRay(ray.origin, ray.direction * RayLength, Color.red, RayTime);



        //    if (Physics.Raycast(ray, out hit, RayLength, layerMask))
        //    {
        //        //hit
        //        Debug.Log(hit.transform.name);
        //        //Debug.Log(hit.point);
        //        Instantiate(_cubeToSpawn, hit.point, Quaternion.identity);
        //    }
        //    else
        //    {
        //         Debug.Log("no hit");
        //        //not hit
        //    }


        // }
    }
}

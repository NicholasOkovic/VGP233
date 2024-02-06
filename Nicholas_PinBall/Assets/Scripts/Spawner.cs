using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    //[SerializeField] private float spawnTime;
    //private float timer;

    [SerializeField] private float _moveSpeed;
    //[SerializeField] private float _leftPos;
    //[SerializeField] private float _rightPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x - _moveSpeed >= -3f)
        {
            transform.Translate(- _moveSpeed, 0, 0, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x + _moveSpeed <= 3f)
        {
            transform.Translate(_moveSpeed, 0, 0, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y + _moveSpeed <= 5f)
        {
            transform.Translate(0, _moveSpeed, 0, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y - _moveSpeed >= 4.5f)
        {
            transform.Translate(0, -_moveSpeed, 0, Space.World);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject g = Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            g.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }

        //timer += Time.deltaTime;
        //if (timer >= spawnTime)
        //{
        //    GameObject g = Instantiate(ballPrefab, new Vector3(Random.Range(_leftPos, _rightPos), transform.position.y), Quaternion.identity);
        //    g.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        //    timer = 0;
        //}
    }
}

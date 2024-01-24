using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float spawnTime;
    private float timer;

    [SerializeField] private float _leftPos;
    [SerializeField] private float _rightPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            GameObject g = Instantiate(ballPrefab, new Vector3(Random.Range(_leftPos, _rightPos), transform.position.y), Quaternion.identity);
            g.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            timer = 0;
        }
    }
}

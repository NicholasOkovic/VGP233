using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TextMeshProUGUI _timer_txt;
    [SerializeField] private GameObject _playerOne;
    private Rigidbody rbOne;

    private float _levelTimer;

    public Vector3 lastCheakPointPos;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        rbOne = _playerOne.GetComponent<Rigidbody>();
        _levelTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _levelTimer += Time.deltaTime;




        //float minutes = Mathf.FloorToInt(_levelTimer / 60);
        //float seconds = Mathf.FloorToInt(_levelTimer % 60);

        //_timer_txt.text = minutes + "::" + seconds;


        _timer_txt.text = _levelTimer.ToString("0.00");
    }
}

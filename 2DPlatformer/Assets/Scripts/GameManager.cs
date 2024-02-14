using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TextMeshProUGUI _gems_txt;
    [SerializeField] private Image _switchNormal;
    [SerializeField] private Image _switchReverse;

    [SerializeField] private GameObject _playerOne;
    private Rigidbody2D rbOne;
    [SerializeField] private GameObject _playerTwo;
    private Rigidbody2D rbTwo;

    private float _timer;
    [SerializeField] private float _cooldown;
    private int gems;

    public Vector2 lastCheakPointPos;

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


        _gems_txt.text = "Gems: " + gems.ToString();

        _switchNormal.enabled = true;
        _switchReverse.enabled = false;

        rbOne = _playerOne.GetComponent<Rigidbody2D>();
        rbTwo = _playerTwo.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Space) && _timer <= 0)
        {
            _timer = _cooldown;
            _playerOne.transform.localScale = new Vector3(1, _playerOne.transform.localScale.y * -1, 1);
            _playerTwo.transform.localScale = new Vector3(1, _playerTwo.transform.localScale.y * -1, 1);
            Player._jumpForce *= -1;
            Player2._jumpForce *= -1;

            rbOne.gravityScale *= -1;
            rbTwo.gravityScale *= -1;

            _switchNormal.enabled = !_switchNormal.enabled;
            _switchReverse.enabled = !_switchReverse.enabled;
        }
    }
    public void AddGem()
    {
        gems++;
        _gems_txt.text = "Gems: " + gems.ToString();
        Debug.Log(gems);
    }


}

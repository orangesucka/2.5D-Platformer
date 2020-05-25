using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private UiManager _uIManager;
    [SerializeField]
    private float _speed = 5f, _gravity = 1f, _jumpHeight = 15f;
    private float _yVelocity;
    public int _coins;

    [SerializeField]
    private bool _doubleJump;

    // Start is called before the first frame update
    void Start()
    {
        _uIManager = GameObject.Find("Canvas").GetComponent<UiManager>();
        if (_uIManager == null)
        {
            Debug.Log("The UI Manager in Player is NULL");
        }
        _controller = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(transform.position.y < -14f)
        {
            transform.position = new Vector3(-22, -7, 0);
        }
    }
    private void Movement()
    {
        float translation = Input.GetAxis("Horizontal");
        Vector3 dircection = new Vector3(translation, 0, 0);
        Vector3 velocity = dircection * _speed;

        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _doubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_doubleJump == true)
                {
                    _yVelocity += _jumpHeight;
                    _doubleJump = false;
                }
            }
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        _controller.Move(velocity * _speed * Time.deltaTime);
    }

    public void coinCounter()
    {
        _coins++;
        _uIManager.UpdateCoinCount(_coins);
    }
}

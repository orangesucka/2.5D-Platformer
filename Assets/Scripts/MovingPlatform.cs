using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private bool _platformA = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 15 && _platformA == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, Time.deltaTime * _speed);
            if (transform.position.y == -5)
            {;
                _platformA = false;
            }
        }
        if(transform.position.y >= -5 && _platformA == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, Time.deltaTime * _speed);
            if (transform.position.y == 15)
            {
                _platformA = true;
            }
        }
        
    }
}

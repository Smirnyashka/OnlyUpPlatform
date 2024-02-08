using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private GameObject _text;

    private Vector3 distance;

    private void Start()
    {
        _text.SetActive(true);
    }

    private bool _isMoved = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isMoved == false)
        {
            _isMoved = true;
            _text.SetActive(false);
        }

        if (_isMoved) 
        { 
            distance = Time.deltaTime * _speed * Vector3.right;
            transform.Translate(distance);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Vector3 distance;

    private void FixedUpdate()
    {
        distance = Time.deltaTime * _speed * Vector3.right;

        transform.Translate(distance);
    }
}

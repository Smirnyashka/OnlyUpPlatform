using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int _speed;
    private Vector2 distance;

    private void FixedUpdate()
    {
        distance = Time.deltaTime * _speed * Vector2.right;

        transform.Translate(distance);
    }


}

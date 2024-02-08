using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    private Movement _movement;
    private Jumping _jumping;
    private CameraFollower _camera;

    public Action GameOver;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _jumping = GetComponent<Jumping>();
        _camera = GetComponent<CameraFollower>();
    }

    public void Reset()
    {
        
    }


}

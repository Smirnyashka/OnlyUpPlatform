using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class EndGame: MonoBehaviour
{

    [SerializeField] private Restart _restart;
    [SerializeField] private CameraFollower _camera;

    public Action OnGameEnded;

    private void LateUpdate()
    {
        if (_camera.GameStopper())
        {
            OnGameEnded?.Invoke();
            _restart.RestartLevel();
            
        }
        else Debug.Log("huinya");

    }
}

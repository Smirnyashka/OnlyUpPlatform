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
    [SerializeField] private Health _health;

    private bool _isComplete;

    public Action OnGameEnded;


    private void OnEnable()
    {
        _health.OnHealthChanged += GameExit;
    }

    private void OnDisable()
    {
        _health.OnHealthChanged -= GameExit;
    }

    private void GameExit()
    {
        _restart.RestartLevel();
    }

    private void LateUpdate()
    {
        if (_camera.GameStopper() && _isComplete == false)
        {
            _isComplete = true;
            OnGameEnded?.Invoke();
        }
    }



}

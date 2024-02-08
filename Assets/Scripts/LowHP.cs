using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowHP : MonoBehaviour
{

    [SerializeField] private Health health;
    [SerializeField] private GameObject _text;
    private Camera _mainCamera;
    private Color _defaultColor;


    private void Start()
    {
        _mainCamera = Camera.main;
        _defaultColor = _mainCamera.backgroundColor;
    }


    private void OnEnable()
    {
        health.OnHealthLow += ChangeSkyColor;
        health.OnHealthLow += DisplayGameOver;
    }

    private void OnDisable()
    {
        health.OnHealthLow -= ChangeSkyColor;
        health.OnHealthLow -= DisplayGameOver;
    }

    private void DisplayGameOver()
    {
        _text.SetActive(true);
        Time.timeScale = 0;
    }

    private void ChangeSkyColor()
    {
        _mainCamera.backgroundColor = Color.grey;

    }
}

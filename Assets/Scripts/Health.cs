using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private EndGame _end;
    [SerializeField] private DataSaver _save;
    [SerializeField] private ResetHealth _reset;

    [SerializeField, Range(1,5)]private int _health;

    public Action OnHealthLow;
    public Action OnHealthChanged;

    public int Healthy => _health;

    private void Awake()
    {
        PreLoad();
    }

    private void OnEnable()
    {
        _end.OnGameEnded += BreakHealth;
        _reset.OnHealthReset += ResetHealth;
    }

    private void OnDisable()
    {
        _end.OnGameEnded -= BreakHealth;
        _reset.OnHealthReset -= ResetHealth;
    }


    private void BreakHealth()
    {

        _health -= 1;
        Debug.Log($"health - {_health}");


        if (_health <= 0)
        {
            Debug.Log("low health");
            _health = 5;
            OnHealthLow?.Invoke();
        _save.Save(_health);
            return;
        }
        OnHealthChanged?.Invoke();
        _save.Save(_health);
    }

    private void ResetHealth()
    {
        _health = 5;
        _save.Save(_health);
        OnHealthChanged?.Invoke();
    }

    private void PreLoad()
    {
        if (PlayerPrefs.HasKey("currentHealth"))
            _health = _save.Load();
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private EndGame _end;
    [SerializeField] private DataSaver _save;

    private int _health = 5;

    public Action OnHealthLow;
    public Action OnHealthChanged;

    public int Healthy => _health;

    private void Start()
    {
        if(PlayerPrefs.HasKey("currentHealth"))
        _health = _save.Load();
    }

    private void OnEnable()
    {
        _end.OnGameEnded += BreakHealth;
    }

    private void OnDisable()
    {
        _end.OnGameEnded -= BreakHealth;
    }


    private void BreakHealth()
    {
        if(_health <= 0)
        {
            Debug.Log("low health");
            _health = 5;
            OnHealthLow?.Invoke();
        }

        else 
        { 
        _health -= 1;
        OnHealthChanged?.Invoke();
        Debug.Log($"health - {_health}");
        }

        _save.Save(_health);
    }


}

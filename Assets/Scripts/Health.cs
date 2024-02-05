using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private EndGame _end;


    public Action OnHealthLow;
    public Action OnHealthChanged;


    public int Healthy => _health;

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
            OnHealthLow?.Invoke();
            return;
        }

        _health -= 1;
        OnHealthChanged?.Invoke();
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHealth : MonoBehaviour
{
    public Action OnHealthReset;


    public void ResetHP()
    {
        Debug.Log("ad watched");
        OnHealthReset?.Invoke();
    }



}

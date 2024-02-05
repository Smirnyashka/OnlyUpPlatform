using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private Health _health;

    public void Save(int data)
    {
        PlayerPrefs.SetInt("currentHealth", data);
    }

    public int Load()
    {
        return PlayerPrefs.GetInt("currentHealth");

    }

}

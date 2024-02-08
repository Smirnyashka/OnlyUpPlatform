using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSaver : MonoBehaviour
{
    public void Save(int data)
    {
        PlayerPrefs.SetInt("currentHealth", data);
    }

    public int Load()
    {
        return PlayerPrefs.GetInt("currentHealth");
    }
}

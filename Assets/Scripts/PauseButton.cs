using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private bool _isActive;

    public void Pause()
    {
        //if(_isActive)
        //{
        //    Time.timeScale = 1.0f;
        //    _isActive = false;
        //}
        //else
        //{
        //    _isActive = true;
        //    Time.timeScale = 0;
        //}
        Time.timeScale = 0;
    }
}

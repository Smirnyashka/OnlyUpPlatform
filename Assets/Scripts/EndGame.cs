using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class EndGame: MonoBehaviour
{
    //[SerializeField] private Transform _player;
    //[SerializeField] private Transform _camera;
    //private float _playerX;
    //private float _cameraX;

    //private void Update()
    //{
    //    if(_playerX - _cameraX > 1)
    //    {
    //        Debug.Log("Game over");
    //    }
    //}

    private Camera mainCamera;
    private float cameraWidth;
    private float cameraHeight;
    private float objectWidth;
    private float objectHeight;

    private void Start()
    {
        mainCamera = Camera.main;

        // Получаем ширину и высоту камеры
        cameraHeight = 2f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;


        objectWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void LateUpdate()
    {
        Vector3 playerPosition = transform.position;
        float xMin = mainCamera.transform.position.x - cameraWidth/2f -1;
        float yMin = mainCamera.transform.position.y - cameraHeight / 2f + objectHeight / 2f;

        if(playerPosition.x < xMin || playerPosition.y < yMin)
        {

            Debug.Log("game over");
            mainCamera.backgroundColor = Color.magenta;

        }


    }
}

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

        // �������� ������ � ������ ������
        cameraHeight = 2f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;

        // �������� ������ � ������ ������� ������
        objectWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void LateUpdate()
    {
        // �������� ������� ������
        Vector3 playerPosition = transform.position;

        // ��������� ������� ������ � ������ ������� ������
        // float xMin = mainCamera.transform.position.x - cameraWidth / 2f + objectWidth / 2f;
        float xMin = mainCamera.transform.position.x - cameraWidth/2f -1;
        float xMax = mainCamera.transform.position.x + cameraWidth / 2f - objectWidth / 2f;
        float yMin = mainCamera.transform.position.y - cameraHeight / 2f + objectHeight / 2f;
        float yMax = mainCamera.transform.position.y + cameraHeight / 2f - objectHeight / 2f;

        // ������������ ������� ������ � �������� ������ ������
        //float clampedX = Mathf.Clamp(playerPosition.x, xMin, xMax);
        //float clampedY = Mathf.Clamp(playerPosition.y, yMin, yMax);

        //// ��������� ������� ������
        //transform.position = new Vector3(clampedX, clampedY, playerPosition.z);

        if(playerPosition.x < xMin)
        {
           // Debug.Log($"��������� ������� ������: {xMin}");
          //  Debug.Log($"��������� ������� ���������: {playerPosition.x}");

            Debug.Log("game over");
        }


    }
}

using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraFollower : MonoBehaviour
    {
        private Camera mainCamera;
        private float cameraWidth;
        private float cameraHeight;
        private float objectWidth;
        private float objectHeight;

        private void Start()
        {
            InitializeCamera();
        }

        public bool GameStopper()
        {
            Vector3 playerPosition = transform.position;
            float xMin = mainCamera.transform.position.x - cameraWidth / 2f - 1;
            float yMin = mainCamera.transform.position.y - cameraHeight / 2f + objectHeight / 2f;

            if (playerPosition.x < xMin || playerPosition.y < yMin)
            {
                return true;
            }
            else return false;
        }


        private void InitializeCamera()
        {
            mainCamera = Camera.main;

            cameraHeight = 2f * mainCamera.orthographicSize;
            cameraWidth = cameraHeight * mainCamera.aspect;

            objectWidth = GetComponent<SpriteRenderer>().bounds.size.x;
            objectHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        }
    }
}
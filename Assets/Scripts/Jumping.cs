using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
        public float jumpForce = 5f;
        public float maxJumpDuration = 2f;

        private bool isJumping = false;
        private float jumpDuration = 0f;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("touch");
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                StartJump();
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                EndJump();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("touch");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

        private void FixedUpdate()
        {
            if (isJumping)
            {
                if (jumpDuration <= maxJumpDuration)
                {
                    // Применяем силу прыжка к Rigidbody2D
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    jumpDuration += Time.fixedDeltaTime;
                }
                else
                {
                    EndJump();
                }
            }
        }

        private void StartJump()
        {
            isJumping = true;
            jumpDuration = 0f;
        }

        private void EndJump()
        {
            isJumping = false;
        }
}

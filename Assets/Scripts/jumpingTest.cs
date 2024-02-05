using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpingTest : MonoBehaviour
{
    public float jumpForce = 5f;
    public float maxJumpDuration = 2f;
    public float jumpAcceleration = 2f;
    public float fallAcceleration = 2f;

    private bool isJumping = false;
    private float jumpDuration = 0f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
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
            StartJump();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("touch");
            EndJump();
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            if (jumpDuration <= maxJumpDuration)
            {
                // Применяем ускорение прыжка к Rigidbody2D
                rb.AddForce(new Vector2(0f, jumpForce * jumpAcceleration), ForceMode2D.Force);
                jumpDuration += Time.fixedDeltaTime;
            }
            else
            {
                // Применяем ускорение спуска к Rigidbody2D
                rb.AddForce(new Vector2(0f, -jumpForce * fallAcceleration), ForceMode2D.Force);
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

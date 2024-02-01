using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Jumping : MonoBehaviour
{
    private Animator _animator;

        [SerializeField, Range(1,30)]private float jumpForce = 10f;
        [SerializeField]private float maxJumpDuration = 2f;

        private bool isJumping = false;
        private float jumpDuration = 0f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
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
            _animator.SetBool("Jump", true);
        }

        private void EndJump()
        {
            isJumping = false;
            _animator.SetBool("Jump", false);
    }
}

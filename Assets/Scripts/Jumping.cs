using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Jumping : MonoBehaviour
{

    [SerializeField, Range(1,30)] private float jumpForce = 10f;
    [SerializeField] private float maxJumpDuration = 2f;
    [SerializeField] private Transform _groundChecker;

    private Animator _animator;
    private bool isJumping = false;
    private bool CanJump=false;
    private bool _isGrounded;
    private float jumpDuration = 0f;
    private float _groundCheckerRadius = 0.2f;
    private LayerMask GroundLayer;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        StartJump();
        //    }
        //    else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        //    {
        //        EndJump();
        //    }
        //}

        _isGrounded = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, GroundLayer);

        if(_isGrounded)
        {
            CanJump = true;
            Debug.Log("hiiiiiiiii");
        }

        if (CanJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
            {
                StartJump();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                EndJump();
            }
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

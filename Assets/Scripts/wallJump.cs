using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallJump : MonoBehaviour
{
    public bool isWallSliding;
    public bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    public float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private float wallJumpingPower = 10f;
    private float wallSlidingSpeed = 1.3f;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform backWallCheck;
    [SerializeField] private LayerMask wallLayer;
    private groundCheckBox gCB;
    private playerMovement pM;
    private Rigidbody2D rb;
    private playerJump pJ;

    // Start is called before the first frame update
    void Start()
    {
        gCB = GetComponent<groundCheckBox>();
        pM = GetComponent<playerMovement>();
        rb = GetComponent<Rigidbody2D>();
        pJ = GetComponent<playerJump>();
    }

    // Update is called once per frame
    void Update()
    {
        WallSlide();
        WallJump();
    }

    private void WallJump()
    {
        if (isWallSliding || (isWallJumping == true && wallJumpingCounter <= 0f))
        {
            isWallJumping = false;
            wallJumpingDirection = pM.isFacingRight ? -1 : 1;
            wallJumpingCounter = wallJumpingTime;
            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            if (pM.moveInput == 0f)
            {
                rb.AddForce(new Vector2(wallJumpingDirection * 5, wallJumpingPower), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(0, wallJumpingPower * 2), ForceMode2D.Impulse);
            }

            wallJumpingCounter = 0f;
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private bool IsOnWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private bool IsBackOnWall()
    {
        return Physics2D.OverlapCircle(backWallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if ((IsOnWall() || IsBackOnWall()) && !gCB.isGrounded())
        {
            isWallSliding = true;
            if (IsBackOnWall())
            {
                if (pM.isFacingLeft) pM.facingRight();
                else pM.facingLeft();
            }
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }
}

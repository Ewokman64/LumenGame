using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallJump : MonoBehaviour
{
    /*public float checkRadius;
    public bool isTouchingFront;
    public Transform frontCheck;
    public Transform frontCheck2;
    public bool wallSliding;
    public bool wallJumping;
    public float wallSlidingSpeed;
    public LayerMask whatIsGround;



    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;

    public float turnVelX;
    public bool jumpedFromLeft;
    public bool jumpedFromRight;*/

    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    private groundCheckBox gCB;
    private playerMovement pM;
    private Rigidbody2D rb;
    private playerJump pJ;

    private Animator anim;
    private string currentState;
    const string PLAYER_WALLGRAB = "wallgrab_Animation";
    const string PLAYER_JUMP = "jump_Animation";


    // Start is called before the first frame update
    void Start()
    {
        gCB = GetComponent<groundCheckBox>();
        pM = GetComponent<playerMovement>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pJ = GetComponent<playerJump>();
    }

    // Update is called once per frame
    void Update()
    {
        WallSlide();
        /*isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);
        isTouchingFront = Physics2D.OverlapCircle(frontCheck2.position, checkRadius, whatIsGround);
        if (isTouchingFront && gCB.isGrounded() == false && pM.moveInput != 0)
        {
            wallSliding = true;
            ChangeAnimationState(PLAYER_WALLGRAB);
            jumpedFromRight = false;
            jumpedFromLeft = false;
        }
        if (isTouchingFront == false || pM.moveInput == 0 || gCB.isGrounded())
        {
            wallSliding = false;
            ChangeAnimationState(PLAYER_JUMP);

        }

        if (wallSliding)
        {
            //locked falling down speed
            rb.velocity = new Vector2(0, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        if (Input.GetKeyDown(KeyCode.Space) && wallSliding == true)
        {
            wallJumping = true;
            ChangeAnimationState(PLAYER_JUMP);
            pJ.doubleJumpAvailable = true;
            Invoke("setWallJumping", wallJumpTime);
        }
        //Moving Left
        if (pM.moveInput == -1)
        {
            if (wallJumping && gCB.isGrounded() == false /*&& jumpedFromRight == false)
            {
                StartCoroutine(timer());
                rb.AddForce(new Vector2(xWallForce, yWallForce), ForceMode2D.Impulse);
                rb.velocity = new Vector2(xWallForce, yWallForce);
                jumpedFromLeft = true;
            }

        }
        if (pM.moveInput == 1)
        {
            if (wallJumping && gCB.isGrounded() == false/* && jumpedFromLeft == false)
            {
                StartCoroutine(timer());
                rb.AddForce(new Vector2(-xWallForce, yWallForce), ForceMode2D.Impulse);
                rb.velocity = new Vector2(-xWallForce, yWallForce);
                jumpedFromRight = true;
            }
        }

        IEnumerator timer()
        {
            pM.canMove = false;
            yield return new WaitForSeconds(0.7f);
            pM.canMove = true;
        }
        /*
        if (jumpedFromLeft)
        {
            //pM.canMove = false;
            //turnVelRight();
        }
        if (jumpedFromRight)
        {
            //pM.canMove = false;
            //turnVelLeft();
        }
        
        
        if (gCB.isGrounded())
        {
            jumpedFromRight = false;
            jumpedFromLeft = false;
        }*/
    }
    /*
    void turnVelRight()
    {
        if (pM.moveInput == 1 || pM.moveInput == 0 || pM.moveInput == -1)
        {
            if (isTouchingFront)
            {
                rb.velocity = new Vector2(turnVelX, rb.velocity.y);
            }
        }
    }
    void turnVelLeft()
    {

        if (pM.moveInput == -1 || pM.moveInput == 0 || pM.moveInput == 1)
        {
            if (isTouchingFront)
            {
                rb.velocity = new Vector2(-turnVelX, rb.velocity.y);
            }
        }
    }
    void setWallJumping()
    {
        wallJumping = false;
    }

    void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play the animation
        anim.Play(newState);

        //reassign the current state
        currentState = newState;
    }*/

    private bool IsOnWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsOnWall() && !gCB.isGrounded() && pM.moveInput != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
    }
}

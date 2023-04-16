using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("Movement Speed")]
    [HideInInspector] public float moveInput;
    public float speed;

    [HideInInspector] public bool isFacingLeft;
    [HideInInspector] public bool isFacingRight;

    [Header("Max Velocity Speed")]
    public float maxSpeedX;
    public float maxSpeedY;
    public bool canMove = true;


    private groundCheckBox gC;
    private Animator anim;
    private playerJump pJ;
    private wallJump wS;
    private Rigidbody2D rb;
    private bool isAttacking;

    #region Animation States
    private string currentState;
    //Normal
    const string PLAYER_IDLE = "idle_Animation";
    const string PLAYER_WALKING = "walking_Animation";
    const string PLAYER_JUMPING = "jump_Animation";
    const string PLAYER_WALLGRAB = "wallgrab_Animation";
    #endregion



    private void Start()
    {
        #region References
        anim = GetComponent<Animator>();
        gC = GetComponent<groundCheckBox>();
        pJ = GetComponent<playerJump>();
        wS = GetComponent<wallJump>();
        rb = GetComponent<Rigidbody2D>();
        #endregion
    }
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (canMove)
        {
            if (isAttacking)
            {
                transform.position += new Vector3(moveInput, 0, 0) * Time.deltaTime * speed * 0.5f;
            }
            else
            {
                transform.position += new Vector3(moveInput, 0, 0) * Time.deltaTime * speed;
            }
        }

        //Facing Right
        if (moveInput > 0f)
        {
            facingRight();
        }

        //Facing Left
        if (moveInput < 0f)
        {
            facingLeft();
        }

        //Locking Max Speed
        if (rb.velocity.magnitude > maxSpeedY)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeedY);
        }
        if (rb.velocity.magnitude > maxSpeedX)
        {
            //Maybe cause of crash
            rb.velocity = new Vector2(Mathf.Clamp(maxSpeedX, 0, 0), rb.velocity.y);
        }
    }

    private void Update()
    {
        if (wS.isWallSliding)
        {
            ChangeAnimationState(PLAYER_WALLGRAB);
        }
        else if (gC.isGrounded() == false && rb.velocity.y != 0 && isAttacking == false && wS.wallJumpingCounter <= 0f)
        {
            ChangeAnimationState(PLAYER_JUMPING);

        }
        //If not moving and is Grounded
        else if (moveInput == 0 && gC.isGrounded() && rb.velocity.y == 0 && isAttacking == false)
        {
            ChangeAnimationState(PLAYER_IDLE);
        }
        else if (gC.isGrounded() && moveInput != 0 && rb.velocity.y <= 0.1f && isAttacking == false)
        {
            ChangeAnimationState(PLAYER_WALKING);
        }

        if (gC.isGrounded())
        {
            canMove = true;
        }
    }
    #region Functions
    public void facingLeft()
    {
        isFacingLeft = true;
        isFacingRight = false;
        gameObject.transform.localScale = new Vector3(-1f, 1f, 1);
    }
    public void facingRight()
    {
        isFacingRight = true;
        isFacingLeft = false;
        gameObject.transform.localScale = new Vector3(1f, 1f, 1);
    }

    void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play the animation
        anim.Play(newState);
        //reassign the current state
        currentState = newState;
    }
    #endregion

    public void Attack(string attackState)
    {
        if (!wS.isWallSliding)
        {
            isAttacking = true;
            ChangeAnimationState(attackState);
        }
    }

    public void StopAttack()
    {
        isAttacking = false;
    }

    public void Jump()
    {
        if (!isAttacking && !wS.isWallSliding)
        {
            ChangeAnimationState(PLAYER_JUMPING);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Destroy(other.gameObject);
        }
    }
}

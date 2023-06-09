using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour
{
    [Header("Jump Height")]
    public float JumpForce;

    private bool jumpIsPressed = false;
    public bool doubleJumpAvailable;
    private Animator anim;
    private Rigidbody2D rigidbod;
    private groundCheckBox gC;
    private playerMovement pM;


    private string currentState;
    const string PLAYER_JUMPING = "jump_Animation";
    const string PLAYER_IDLE = "idle_Animation";

    void Start()
    {
        gC = GetComponent<groundCheckBox>();
        anim = GetComponent<Animator>();
        rigidbod = GetComponent<Rigidbody2D>();
        pM = GetComponent<playerMovement>();
    }
    void FixedUpdate()
    {
        if (gC.isGrounded() && jumpIsPressed)
        {
            jump();
        }
        if (rigidbod.velocity.y <= 0.01 && gC.isGrounded())
        {
            jumpIsPressed = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gC.isGrounded())
            {
                jumpIsPressed = true;
            }
        }

        if (doubleJumpAvailable)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                doubleJump();

            }
        }
        if (gC.isGrounded() == false)
        {
            jumpIsPressed = false;
        }
        if (gC.isGrounded() && rigidbod.velocity.y < 0.1f)
        {
            doubleJumpAvailable = false;
        }

        //Cut Jump
        /*
        if (Input.GetKeyUp(KeyCode.Space) && rigidbod.velocity.y >= 2f && doubleJumpAvailable == true)
        {
            //If let go of Space, you will be pushed down
            JumpCut();
        }*/


    }


    #region Functions
    void jump()
    {
        ChangeAnimationState(PLAYER_JUMPING);
        doubleJumpAvailable = true;
        rigidbod.velocity = new Vector2(0, 0);
        rigidbod.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

        PlayerSound.Instance.PlayJumpSound();
    }
    void doubleJump()
    {
        ChangeAnimationState(PLAYER_JUMPING);
        rigidbod.velocity = new Vector2(0, 0);
        rigidbod.AddForce(new Vector2(0, JumpForce / 1.5f), ForceMode2D.Impulse);
        doubleJumpAvailable = false;

        PlayerSound.Instance.PlayJumpSound();
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
}

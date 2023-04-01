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
    private Rigidbody2D rb;

    #region Animation States
    private string currentState;
    //Normal
    const string PLAYER_IDLE = "idle_Animation";
    const string PLAYER_WALKING = "walking_Animation";
    const string PLAYER_JUMPING = "jump_Animation";
    #endregion



    private void Start()
    {
        #region References
        anim = GetComponent<Animator>();
        gC = GetComponent<groundCheckBox>();
        pJ = GetComponent<playerJump>();
        rb = GetComponent<Rigidbody2D>();
        #endregion
    }
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (canMove)
        {
            transform.position += new Vector3(moveInput, 0, 0) * Time.deltaTime * speed;
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
        if (gC.isGrounded() == false && rb.velocity.y != 0)
        {
             ChangeAnimationState(PLAYER_JUMPING);

        }
        //If not moving and is Grounded
        if (moveInput == 0 && gC.isGrounded() && rb.velocity.y == 0)
        {
            ChangeAnimationState(PLAYER_IDLE);
        }
        if (gC.isGrounded() && moveInput != 0 && rb.velocity.y <= 0.1f)
        {
            ChangeAnimationState(PLAYER_WALKING);
        }
        if (gC.isGrounded())
        {
            canMove = true;
        }
    }
    #region Functions
    void facingLeft()
    {
        isFacingLeft = true;
        isFacingRight = false;
        gameObject.transform.localScale = new Vector3(-1f, 1f, 1);
    }
    void facingRight()
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

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.tag == "Weapon")
        {
            Destroy(other.gameObject);
        } 
    }
}

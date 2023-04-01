using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDash : MonoBehaviour
{
    private groundCheckBox gCB;
    private playerMovement pM;

    public float dashForce;
    public float startDashTimer;
    float currentDashTime;
    float dashDirection;
    private Rigidbody2D rb;
    bool isDashing;
    bool dashed;

    public float startTime = 1f;
    public bool canDash = true;


    // Start is called before the first frame update
    void Start()
    {
        gCB = GetComponent<groundCheckBox>();
        pM = GetComponent<playerMovement>();
        rb = GetComponent<Rigidbody2D>();
        canDash = true;
        startTime = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            startTime = 1f;          
        }
        if (dashed)
        {
            canDash = false;
            startTime -= Time.deltaTime;
            if (startTime <= 0)
            {
                canDash = true;
                dashed = false;
            }
            else
            {
                canDash = false;
            }
        }
        

        if (Input.GetKeyDown(KeyCode.LeftShift) && pM.moveInput != 0 && canDash)
        {
            isDashing = true;
            dashed = true;
            currentDashTime = startDashTimer;
            rb.velocity = Vector2.zero;
            dashDirection = (int)pM.moveInput;
            
        }
        if (isDashing)
        {
            rb.velocity = transform.right * dashDirection * dashForce;

            currentDashTime -= Time.deltaTime;
            if(currentDashTime <= 0)
            {
                isDashing = false;
            }
        }

        
    }
}

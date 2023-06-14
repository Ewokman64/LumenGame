using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadowbug : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        IDLE = "ShadowBug_idle";
        ATTACK = "Attack_ShadowBug";
        DAMAGED = "Damaged_ShadowBug";
        DEATH = "Death_ShadowBug";
        currentState = "ShadowBug_idle";
        gC = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = 2;
    }

    public bool isGrounded()
    {
        return grounded = Physics2D.BoxCast(gC.bounds.center, new Vector2(0.4f, 0.1f), 0f, Vector2.down, .05f, walkableGround);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!isGrounded())
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1f, 1f, 1f);
        }
        if (currentState == IDLE)
        {
            Move();
        }

    }
    void Move()
    {
        transform.position += new Vector3(gameObject.transform.localScale.x * -1, 0, 0) * Time.deltaTime * speed;
    }

    override public void Damage()
    {
        isAttacking = false;
        health -= 1;
        if (health <= 0)
        {
            ChangeAnimationState(DEATH);
            GameObject.Destroy(gameObject);
        }
        else
            ChangeAnimationState(DAMAGED);
    }
}

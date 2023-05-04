using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadowbug : MonoBehaviour
{
    private BoxCollider2D gC;
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] LayerMask walkableGround;
    public float speed;

    private string IDLE = "ShadowBug_idle";
    private string ATTACK = "Attack_ShadowBug";
    private string DAMAGED = "Damaged_ShadowBug";
    private string DEATH = "Death_ShadowBug";
    
    public bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        gC = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public bool isGrounded(){
        return grounded = Physics2D.BoxCast(gC.bounds.center, new Vector2(0.4f, 0.1f), 0f, Vector2.down, .05f, walkableGround);
    }

    void Update(){

    }

    void FixedUpdate(){
        if (!isGrounded()){
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1f,1f,1f);
        }
        Move();
    }
    void Move(){
        transform.position += new Vector3(gameObject.transform.localScale.x*-1, 0, 0) * Time.deltaTime * speed;
    }
}

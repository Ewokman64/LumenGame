using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class groundCheckBox : MonoBehaviour
{
    [Header("References")]
    public bool grounded;
    [SerializeField] LayerMask jumpableGround;

    private CapsuleCollider2D coll;
    private GameObject hitObject;

    private void Start()
    {
        coll = GetComponent<CapsuleCollider2D>();
    }
    public bool isGrounded()
    {
        return grounded = Physics2D.BoxCast(coll.bounds.center - new Vector3(0f, 0.35f), new Vector2(0.4f, 0.1f), 0f, Vector2.down, .05f, jumpableGround);
    }

    #region Update
    void Update()
    {
        RaycastHit2D hit;
        hit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 0.05f, jumpableGround);

    }
    #endregion

    //Visuals of BoxCast
    /*
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(coll.bounds.center, new Vector3(coll.bounds.size.x, 0.05f, 0f));
    }*/
}


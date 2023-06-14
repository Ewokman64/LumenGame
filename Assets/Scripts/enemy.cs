
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    protected BoxCollider2D gC;
    protected Animator anim;
    protected Rigidbody2D rb;
    [SerializeField] protected LayerMask walkableGround;
    public float speed;

    protected string IDLE;
    protected string ATTACK;
    protected string DAMAGED;
    protected string DEATH;
    protected string currentState;

    public bool grounded;
    protected int health;
    protected bool isAttacking;

    protected void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;
        //play the animation
        Debug.Log(newState);
        anim.Play(newState);
        //reassign the current state
        currentState = newState;
    }

    abstract public void Damage();
}

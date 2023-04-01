using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private string currentState;
    private Animator anim;
    public bool isArmed;
    const string Player_Attack1 = "attack1";
    const string Player_Attack2 = "attack2";
    const string Player_Attack3 = "attack3";
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) /*&& isArmed == true*/)
        {
            //ChangeAnimationState(Player_Attack1);
            Debug.Log("Attack1");
        }
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
}

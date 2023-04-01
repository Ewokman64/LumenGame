using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatScript : MonoBehaviour
{
    private string currentState;
    private Animator anim;
    public float comboWindow = 0;
    public bool isArmed;
    public bool attacked1 = false;
    public bool attacked2 = false;
    public bool attacked3 = false;
    const string Player_Attack1 = "Attack1";
    const string Player_Attack2 = "Attack2";
    const string Player_Attack3 = "Attack3";
    const string Player_Idle = "idle_Animation";
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        //ALL THE BOOLS GET SET AT ONCE. FIX IT!!!
        if (Input.GetKeyDown(KeyCode.Mouse0) && isArmed == true)
        {
            ChangeAnimationState(Player_Attack1);
            attacked1 = true;
            comboWindow = 1;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && isArmed == true && attacked1 == true && comboWindow != 0)
        {
            ChangeAnimationState(Player_Attack2);
            attacked2 = true;
            comboWindow = 1;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && isArmed == true && attacked2 == true && comboWindow != 0)
        {
            ChangeAnimationState(Player_Attack3);
            attacked3 = true; 
            Invoke("SetBoolBack", 1);
        }
        if (comboWindow > 0)
        {
            comboWindow -= Time.deltaTime;
        }
        else
        {
            comboWindow = 0;
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

    private void SetBoolBack()
    {
        attacked1 = false;
        attacked2 = false;
        attacked3 = false;
        ChangeAnimationState(Player_Idle);
    }
}

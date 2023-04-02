using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatScript : MonoBehaviour
{
    private string currentState;
    private Animator anim;
    public float comboWindow = 0;
    public bool isArmed;
    public int attackCount = 0;
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && isArmed == true && attackCount == 0)
        {
            ChangeAnimationState(Player_Attack1);
            attackCount = 1;
            comboWindow = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && isArmed == true && attackCount == 1 && comboWindow != 0)
        {
            ChangeAnimationState(Player_Attack2);
            attackCount = 2;
            comboWindow = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && isArmed == true && attackCount == 2 && comboWindow != 0)
        {
            ChangeAnimationState(Player_Attack3);
            attackCount = 3;
            Invoke("SetBoolBack", 1);
        }
        if (comboWindow > 0)
        {
            comboWindow -= Time.deltaTime;
        }
        else if (comboWindow <= 0 && attackCount > 0)
        {
            Invoke("SetBoolBack", 1);
        }
    }
    void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState)
        {
            return;
        }
        if (newState == Player_Attack2) Debug.Log("ATTACK 2");

        //play the animation
        anim.Play(newState);

        //reassign the current state
        currentState = newState;
    }

    private void SetBoolBack()
    {
        comboWindow = 0;
        attackCount = 0;
        ChangeAnimationState(Player_Idle);
    }
}

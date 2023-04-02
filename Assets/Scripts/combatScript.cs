using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatScript : MonoBehaviour
{
    private string currentState;
    private playerMovement movement;
    public float comboWindow = 0;
    public float timeSinceAttack = 0;
    public bool isArmed;
    public int attackCount = 0;
    const string Player_Attack1 = "Attack1";
    const string Player_Attack2 = "Attack2";
    const string Player_Attack3 = "Attack3";
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<playerMovement>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (attackCount > 0) timeSinceAttack += Time.deltaTime;
        else timeSinceAttack = 0;

        if (Input.GetKeyDown(KeyCode.Mouse0) && isArmed == true && attackCount == 0 && timeSinceAttack == 0)
        {
            movement.Attack(Player_Attack1);
            attackCount = 1;
            comboWindow = 1;
            timeSinceAttack = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && isArmed == true && attackCount == 1 && comboWindow != 0 && timeSinceAttack > 0.3)
        {
            movement.Attack(Player_Attack2);
            attackCount = 2;
            comboWindow = 1;
            timeSinceAttack = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && isArmed == true && attackCount == 2 && comboWindow != 0 && timeSinceAttack > 0.4)
        {
            movement.Attack(Player_Attack3);
            attackCount = 3;
            timeSinceAttack = 0;
        }
        if (comboWindow > 0)
        {
            comboWindow -= Time.deltaTime;
        }
        else if (comboWindow <= 0 && attackCount > 0 && timeSinceAttack > 0.5)
        {
            ResetAttack();
        }
    }

    private void ResetAttack()
    {
        comboWindow = 0;
        attackCount = 0;
        movement.StopAttack();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollision : MonoBehaviour
{
    public int hp = 3;
    public combatScript combatScript;
    // Start is called before the first frame update
    void Start()
    {
        //combatScript = gameObject.GetComponent<combatScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("You died"!);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == ("ShadowBug"))
        {
            Debug.Log("You got hit! -1 HP");
            hp--;
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Weapon"))
        {
            combatScript.isArmed = true;
            Destroy(other.gameObject);
        }
    }
}

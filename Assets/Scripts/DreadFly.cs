using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreadFly : MonoBehaviour
{
    public int dread_HP = 3;
    public GameObject key;
    public Transform keySpawnLocation;
    public bool hasDroppedKey;
    private Animator animator;

    // Update is called once per frame
    void Start()
    {
        hasDroppedKey = false;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (dread_HP <= 0 && hasDroppedKey == false)
        {
            DropKey();
            animator.SetTrigger("Death_DreadFly");
            hasDroppedKey = true;
        }
    }
    void DropKey()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0f, 2f, 0f);
        Instantiate(key, spawnPosition, UnityEngine.Quaternion.identity);
    }
}

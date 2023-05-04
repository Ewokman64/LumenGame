using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreadFly : MonoBehaviour
{
    public int dread_HP = 3;
    public GameObject key;
    public Transform keySpawnLocation;
    public bool hasDroppedKey;

    // Update is called once per frame
    void Start()
    {
        hasDroppedKey = false;   
    }
    void Update()
    {
        if (dread_HP <= 0 && hasDroppedKey == false)
        {
            DropKey();
            hasDroppedKey = true;
        }
    }
    void DropKey()
    {
        Instantiate(key, keySpawnLocation.position, UnityEngine.Quaternion.identity);
    }
}

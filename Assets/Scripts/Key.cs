using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] int keyAmount;
    [SerializeField] GameObject redPrism;
    [SerializeField] Transform spawnLocation;

    private bool allow = true;
    public GameObject prismSpawner;



    private void Update()
    {
        if(keyAmount == 3 && allow)
        {
            prismSpawner.SetActive(true);
            //SpawnPrism();
            allow = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == ("Key"))
        {
            keyAmount++;
            Destroy(other.gameObject);
        }      
    }
}

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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Key"))
        {
            keyAmount++;
            Destroy(other.gameObject);
        }      
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        /*if (other.gameObject.tag == ("PrismRoom") && keyAmount == 3)
        {
            SpawnPrism();
        }*/
    }

    /*void SpawnPrism()
    {
        Instantiate(redPrism, spawnLocation.transform.position, Quaternion.identity);
    }*/
}

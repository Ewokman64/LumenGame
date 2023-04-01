using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterRoomSpawnPrism : MonoBehaviour
{
    public GameObject redPrism;
    public Transform spawnLocation;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(redPrism, spawnLocation.transform.position, Quaternion.identity);
        }
    }
}

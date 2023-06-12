using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PushPull : MonoBehaviour
{
    public float interactionDistance = 0.3f;
    private bool interacting;

    private Rigidbody2D[] pushPullObjects;
    // Start is called before the first frame update
    void Start()
    {
        pushPullObjects = GameObject.FindGameObjectsWithTag("Light")
                          .Select(obj => obj.GetComponent<Rigidbody2D>())
                          .ToArray();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            foreach (var obj in pushPullObjects)
            {
                if (Vector3.Distance(transform.position, obj.transform.position) <= interactionDistance)
                {
                    // Player is close enough to interact with the object
                    // Add your push/pull logic here, for example:
                    Vector3 pushPullDirection = obj.transform.position - transform.position;
                    obj.AddForce(pushPullDirection.normalized * 1f, ForceMode2D.Force);
                }
            }
        }
    }
}
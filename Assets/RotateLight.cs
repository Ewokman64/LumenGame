using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour
{
    private Transform objectTransform;

    public float rotationSpeed = 100f;

    public Transform rotationPoint;

    // Start is called before the first frame update
    private void Start()
    {
        objectTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        float rotation = 0f;

        if (Input.GetKey(KeyCode.E))
        {
            rotation = rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            rotation = -rotationSpeed * Time.deltaTime;
        }

        objectTransform.RotateAround(rotationPoint.position, Vector3.forward, rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomOut : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float zoomOutFOV = 60f;
    private float originalFOV = 40f;
    private float heightToAdd = 5f;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            virtualCamera.m_Lens.FieldOfView = zoomOutFOV;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Get the current position of the Transform
        Vector3 currentPosition = transform.position;
        if (other.gameObject.CompareTag("Player"))
        {
            virtualCamera.m_Lens.FieldOfView = originalFOV;
        }
    }
}

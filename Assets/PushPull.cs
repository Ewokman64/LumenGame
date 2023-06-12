using UnityEngine;

public class PushPull : MonoBehaviour
{
    public KeyCode grabKey = KeyCode.G;
    private bool isGrabbing = false;
    private GameObject grabbedObject;

    private void Update()
    {
        if (Input.GetKeyDown(grabKey))
        {
            isGrabbing = true;
        }
        else if (Input.GetKeyUp(grabKey))
        {
            isGrabbing = false;
            ReleaseObject();
        }

        if (isGrabbing && grabbedObject != null)
        {
            // Move the grabbed object based on player's movement
            Vector2 playerMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            grabbedObject.transform.Translate(playerMovement * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isGrabbing && grabbedObject == null && other.CompareTag("MovableObject"))
        {
            grabbedObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (grabbedObject != null && other.gameObject == grabbedObject)
        {
            grabbedObject = null;
        }
    }

    private void ReleaseObject()
    {
        grabbedObject = null;
    }
}

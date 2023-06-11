using UnityEngine;
using System.Collections;

public class SpriteFlipper : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ToggleFlipX());
    }

    private IEnumerator ToggleFlipX()
    {
        while (true)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX; // Toggle flipX property

            yield return new WaitForSeconds(0.5f); // Wait for 0.5 second
        }
    }
}

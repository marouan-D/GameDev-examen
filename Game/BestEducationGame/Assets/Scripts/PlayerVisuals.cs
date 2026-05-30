using UnityEngine;
using System.Collections;

public class PlayerFeedback : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Vector3 originalScale;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        originalScale = transform.localScale;
    }

    // Aangeroepen wanneer een boek wordt gevangen — raket wordt kort groter
    public void FlashCatch()
    {
        StopAllCoroutines();
        StartCoroutine(Pulse(1.3f, 0.15f));
    }

    // Aangeroepen wanneer een meteor wordt gevangen — raket flitst kort zwart
    public void FlashHit()
    {
        StopAllCoroutines();
        StartCoroutine(FlashColor(Color.black, 0.15f));
    }

    IEnumerator FlashColor(Color flashColor, float duration)
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = originalColor;
    }

    IEnumerator Pulse(float scaleMultiplier, float duration)
    {
        transform.localScale = originalScale * scaleMultiplier;
        yield return new WaitForSeconds(duration);
        transform.localScale = originalScale;
    }
}
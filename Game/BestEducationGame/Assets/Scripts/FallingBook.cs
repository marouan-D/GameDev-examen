using UnityEngine;

public class FallingBook : MonoBehaviour
{
    // Hoeveel punten dit object oplevert als je het vangt (voor boeken)
    public int scoreValue = 1;

    // True als dit object een meteoor is — kost een leven i.p.v. punten te geven
    public bool isMeteor = false;

    // Valsnelheid en grens om buiten beeld op te ruimen
    public float fallSpeed = 3f;
    public float destroyY = -6f;

    void Update()
    {
        // Beweeg het object omlaag, langs de wereld-as
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

        // Vernietig het object als 't onder het scherm valt
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Trigger de visuele flash op de raket
        PlayerFeedback feedback = other.GetComponent<PlayerFeedback>();
        if (feedback != null)
        {
            if (isMeteor)
            {
                feedback.FlashHit();
            }
            else
            {
                feedback.FlashCatch();
            }
        }

        // Score of leven aanpassen via de GameManager
        if (GameManager.Instance != null)
        {
            if (isMeteor)
            {
                GameManager.Instance.LoseLife();
            }
            else
            {
                GameManager.Instance.AddScore(scoreValue);
            }
        }

        Destroy(gameObject);
    }
}
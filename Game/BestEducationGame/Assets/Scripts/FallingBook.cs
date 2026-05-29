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
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.Instance != null)
        {
            if (isMeteor)
            {
                // Meteoren kosten een leven
                GameManager.Instance.LoseLife();
            }
            else
            {
                // Boeken geven punten
                GameManager.Instance.AddScore(scoreValue);
            }
        }

        Destroy(gameObject);
    }
}
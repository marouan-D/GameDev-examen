using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Snelheid van de raket (eenheden per seconde) — zichtbaar in de Inspector
    public float speed = 5f;

    void Update()
    {
        // Lees input: -1 = links (A of pijltje links), +1 = rechts (D of pijltje rechts), 0 = niks
        float horizontal = Input.GetAxisRaw("Horizontal");

        // Beweeg de raket horizontaal; Time.deltaTime maakt 't onafhankelijk van framerate
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime, Space.World);
    }
}
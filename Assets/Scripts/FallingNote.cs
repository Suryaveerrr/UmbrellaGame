using UnityEngine;

public class FallingNote : MonoBehaviour
{
    public int noteID; // 0=Red, 1=Blue, etc.
    public float fallSpeed = 10f;
    public float spinSpeed = 100f;

    private bool hasTriggered = false; // Prevents double hits

    void Update()
    {
        // Fall & Spin
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime, Space.World);

        // Safety destroy if it falls way below map (just in case)
        if (transform.position.y < -10f) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        // 1. CAUGHT BY PLAYER (GOOD)
        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            MusicManager.Instance.NoteCaught(noteID); // Play Sound
            Destroy(gameObject);
        }
        // 2. HIT THE FLOOR (BAD)
        else if (other.CompareTag("Finish"))
        {
            hasTriggered = true;
            MusicManager.Instance.NoteMissed(); // GAME OVER!
            Destroy(gameObject);
        }
    }
}
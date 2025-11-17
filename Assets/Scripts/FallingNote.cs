using UnityEngine;

public class FallingNote : MonoBehaviour
{
    [Header("Identity")]
    public int noteID; // Set this in Prefab! 0=Red, 1=Blue, 2=Green, 3=Yellow

    [Header("Movement")]
    public float fallSpeed = 4f;
    public float spinSpeed = 100f;

    void Update()
    {
        // Fall (World Space)
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

        // Spin (World Up Axis)
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime, Space.World);

        // Destroy if missed (below floor)
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // HIT PLAYER
        if (other.CompareTag("Player"))
        {
            // Tell Manager WHAT we caught (0, 1, 2, or 3)
            MusicManager.Instance.CheckCaughtNote(noteID);
            Destroy(gameObject);
        }
        // HIT FLOOR
        else if (other.CompareTag("Finish"))
        {
            // Just destroy for now. 
            // Uncomment next line if you want Game Over on ANY miss:
            // MusicManager.Instance.GameOver();
            Destroy(gameObject);
        }
    }
}
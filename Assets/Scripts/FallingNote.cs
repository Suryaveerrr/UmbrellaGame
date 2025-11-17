using UnityEngine;

public class FallingNote : MonoBehaviour
{
    public float fallSpeed = 4f;
    public float spinSpeed = 100f;

    void Update()
    {
        // 1. Fall Down (World Space)
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

        // 2. Spin Horizontally (World Space)
        // "Vector3.up" here means the global green Y axis
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime, Space.World);

        // 3. Destroy if off screen
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Hit Player = Good
        if (other.CompareTag("Player"))
        {
            MusicManager.Instance.PlayNextNote();
            Destroy(gameObject);
        }
        // Hit Floor (tagged as Finish) = Bad
        else if (other.CompareTag("Finish"))
        {
            Debug.Log("Game Over!"); // Debug check
            MusicManager.Instance.GameOver(); // Call the manager
            Destroy(gameObject);
        }
    }
}
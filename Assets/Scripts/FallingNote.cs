using UnityEngine;

public class FallingNote : MonoBehaviour
{
    public int noteID; 
    public float fallSpeed = 10f;
    public float spinSpeed = 100f;

    private bool hasTriggered = false; // Prevents double hits

    void Update()
    {
        // Fall & Spin
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime, Space.World);

       
        if (transform.position.y < -10f) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        
        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            MusicManager.Instance.NoteCaught(noteID); 
            Destroy(gameObject);
        }
       
        else if (other.CompareTag("Finish"))
        {
            hasTriggered = true;
            MusicManager.Instance.NoteMissed(); 
            Destroy(gameObject);
        }
    }
}

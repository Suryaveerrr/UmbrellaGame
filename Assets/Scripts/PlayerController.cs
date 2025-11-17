using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 10f;
    public float xLimit = 8f; // How far left/right she can go

    [Header("Animation")]
    public Animator animator; // Drag your Animator component here

    void Update()
    {
        // 1. Get Input (-1 for Left, +1 for Right)
        float moveInput = Input.GetAxis("Horizontal");

        // 2. Move the Player
        // We use Space.World to ensure she moves relative to the screen, 
        // regardless of which way she is facing.
        transform.Translate(Vector3.right * moveInput * speed * Time.deltaTime, Space.World);

        // 3. Clamp Position (Keep her on screen)
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -xLimit, xLimit);
        transform.position = currentPosition;

        // 4. Update Animation
        // Sends the "-1" or "1" to the Animator to trigger the transitions
        if (animator != null)
        {
            animator.SetFloat("SpeedX", moveInput);
        }
    }
}
using UnityEngine;
using DG.Tweening; 

public class PlayerController : MonoBehaviour
{
    [Header("Lane Settings")]
    public float laneDistance = 2f; // Left: -2, Mid: 0, Right: 2
    public float moveDuration = 0.2f; // How long the slide takes (Lower = Faster)

    private int currentLane = 1; // 0 = Left, 1 = Middle, 2 = Right

    [Header("Animation")]
    public Animator animator;

    void Update()
    {
        // 1. Detect Input
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLane(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveLane(1);
        }

       
    }

    void MoveLane(int direction)
    {
        // Calculate Target Lane
        int targetLane = currentLane + direction;

        // Clamp (Don't go beyond lane 0 or 2)
        if (targetLane < 0 || targetLane > 2) return;

        currentLane = targetLane;

        // Calculate Target X Position
        float targetX = 0;
        if (currentLane == 0) targetX = -laneDistance;
        else if (currentLane == 1) targetX = 0;
        else if (currentLane == 2) targetX = laneDistance;

        
        transform.DOMoveX(targetX, moveDuration).SetEase(Ease.OutQuad);

        // Animation Trigger
        if (animator != null)
        {
            animator.SetFloat("SpeedX", direction);
            // Reset animation to 0 after a tiny delay so she doesn't stay leaning
            DOVirtual.DelayedCall(0.2f, () => animator.SetFloat("SpeedX", 0));
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [Header("Audio")]
    public AudioSource audioSource;
    // 0:Red, 1:Blue, 2:Green, 3:Yellow
    public AudioClip[] noteSounds;
    public AudioClip gameOverSound;

    [Header("UI")]
    public GameObject gameOverPanel;

    void Awake()
    {
        Instance = this;
    }

    // Called when Player catches a note
    public void NoteCaught(int noteID)
    {
        // Play the sound for that specific color
        if (noteID >= 0 && noteID < noteSounds.Length)
        {
            audioSource.PlayOneShot(noteSounds[noteID]);
        }
    }

    // Called when a note hits the FLOOR
    public void NoteMissed()
    {
        Debug.Log("Note hit the floor! Game Over.");

        // Play Fail Sound
        if (gameOverSound != null) audioSource.PlayOneShot(gameOverSound);

        // Stop Game
        GameOver();
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // Pause
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
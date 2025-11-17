using UnityEngine;
using UnityEngine.SceneManagement; // Needed to reload the scene
using UnityEngine.UI; // Needed for UI

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioSource audioSource;
    public AudioClip[] musicNotes;
    private int currentNoteIndex = 0;

    [Header("UI Connections")]
    public GameObject gameOverPanel; // Drag your Panel here

    void Awake()
    {
        Instance = this;
    }

    public void PlayNextNote()
    {
        if (musicNotes.Length == 0) return;
        audioSource.PlayOneShot(musicNotes[currentNoteIndex]);
        currentNoteIndex++;
        if (currentNoteIndex >= musicNotes.Length) currentNoteIndex = 0;
    }

    public void GameOver()
    {
        // 1. Show the cursor so we can click
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // 2. Pause the game
        Time.timeScale = 0f;

        // 3. Show the UI
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        // 1. Unpause
        Time.timeScale = 1f;

        // 2. Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
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

   
    public void NoteCaught(int noteID)
    {
        
        if (noteID >= 0 && noteID < noteSounds.Length)
        {
            audioSource.PlayOneShot(noteSounds[noteID]);
        }
    }

    
    public void NoteMissed()
    {
        Debug.Log("Note hit the floor! Game Over.");

        
        if (gameOverSound != null) audioSource.PlayOneShot(gameOverSound);

        
        GameOver();
    }

    public void GameOver()
    {
        Time.timeScale = 0f; 
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

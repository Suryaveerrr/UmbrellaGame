using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    // Drag sounds here: 0:Red(C), 1:Blue(E), 2:Green(G), 3:Yellow(High C)
    public AudioClip[] noteSounds;
    public AudioClip wrongNoteSound; // Drag your "Buzz" or "Error" sound here

    [Header("Sequence Logic")]
    public int sequenceLength = 8; // How many notes to show at once
    public List<int> targetSequence = new List<int>();
    private int currentTargetIndex = 0;

    [Header("UI Connections")]
    public Transform sequenceBar; // Drag the "SequenceBar" Panel
    public GameObject uiNotePrefab; // Drag the "UI_Note" Prefab (with the White Note Image)
    public GameObject gameOverPanel; // Drag the Game Over Panel

    // Colors: Element 0=Red, 1=Blue, 2=Green, 3=Yellow
    public Color[] noteColors;

    private List<GameObject> spawnedIcons = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateRandomSequence();
    }

    public void GenerateRandomSequence()
    {
        // 1. Cleanup old icons
        foreach (GameObject icon in spawnedIcons) Destroy(icon);
        spawnedIcons.Clear();
        targetSequence.Clear();
        currentTargetIndex = 0;

        // 2. Generate new list
        for (int i = 0; i < sequenceLength; i++)
        {
            int randomID = Random.Range(0, 4); // Pick 0, 1, 2, or 3
            targetSequence.Add(randomID);

            // 3. Create UI Icon
            GameObject newIcon = Instantiate(uiNotePrefab, sequenceBar);

            // CRITICAL FIX: Force scale to 1 so it doesn't turn invisible
            newIcon.transform.localScale = Vector3.one;

            // 4. Tint the White Sprite to the correct color
            newIcon.GetComponent<Image>().color = noteColors[randomID];

            spawnedIcons.Add(newIcon);
        }
        Debug.Log("New Sequence Generated!");
    }

    public void CheckCaughtNote(int caughtID)
    {
        if (targetSequence.Count == 0) return;

        // 1. Check what we needed to catch
        int neededID = targetSequence[currentTargetIndex];

        if (caughtID == neededID)
        {
            // --- SUCCESS ---
            Debug.Log("Correct!");

            // Play the happy note
            if (caughtID < noteSounds.Length)
                audioSource.PlayOneShot(noteSounds[caughtID]);

            // Remove the first icon in the UI bar
            if (spawnedIcons.Count > 0)
            {
                Destroy(spawnedIcons[0]);
                spawnedIcons.RemoveAt(0);
            }

            // Advance sequence
            currentTargetIndex++;

            // Win Condition: If finished, generate a new song
            if (currentTargetIndex >= targetSequence.Count)
            {
                GenerateRandomSequence();
            }
        }
        else
        {
            // --- FAILURE (STRICT GAME OVER) ---
            Debug.Log("Wrong Note! Needed: " + neededID + " Got: " + caughtID);

            // Play error sound
            if (wrongNoteSound != null) audioSource.PlayOneShot(wrongNoteSound);

            // End the game
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f; // Pause physics

        // Unlock mouse
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Show UI
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Unpause
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
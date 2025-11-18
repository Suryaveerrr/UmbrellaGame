using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject[] notePrefabs;
    public Transform player;

    [Header("Settings")]
    public float spawnInterval = 0.6f; // Faster spawning!
    public float laneDistance = 3f; // MUST match the Player's lane distance

    void Start()
    {
        InvokeRepeating("SpawnNote", 1f, spawnInterval);
    }

    void SpawnNote()
    {
        if (player == null || notePrefabs.Length == 0) return;

        // 1. Pick Random Note Color
        GameObject selectedPrefab = notePrefabs[Random.Range(0, notePrefabs.Length)];

        // 2. Pick Random Lane (0, 1, or 2)
        int randomLaneIndex = Random.Range(0, 3);
        float spawnX = 0f;

        if (randomLaneIndex == 0) spawnX = -laneDistance;
        else if (randomLaneIndex == 1) spawnX = 0f;
        else if (randomLaneIndex == 2) spawnX = laneDistance;

        // 3. Spawn Position
        Vector3 spawnPos = new Vector3(spawnX, 10f, player.position.z);

        // 4. Instantiate
        Instantiate(selectedPrefab, spawnPos, selectedPrefab.transform.rotation);
    }
}
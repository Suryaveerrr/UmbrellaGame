using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [Header("Setup")]
    // Change Size to 4 and drag Prefabs: Red, Blue, Green, Yellow
    public GameObject[] notePrefabs;
    public Transform player;

    [Header("Settings")]
    public float spawnInterval = 1.0f;
    public float xRange = 7f;

    void Start()
    {
        InvokeRepeating("SpawnNote", 1f, spawnInterval);
    }

    void SpawnNote()
    {
        if (player == null || notePrefabs.Length == 0) return;

        // 1. Pick a random color
        int randomIndex = Random.Range(0, notePrefabs.Length);
        GameObject selectedPrefab = notePrefabs[randomIndex];

        // 2. Position (Match Player Z)
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 10f, player.position.z);

        // 3. Spawn (Keep Prefab Rotation)
        Instantiate(selectedPrefab, spawnPos, selectedPrefab.transform.rotation);
    }
}
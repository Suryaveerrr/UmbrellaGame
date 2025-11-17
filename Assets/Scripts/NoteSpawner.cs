using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform player; // NEW: We will drag the girl here so we know her Z position
    public float spawnInterval = 1.0f;
    public float xRange = 7f;

    void Start()
    {
        InvokeRepeating("SpawnNote", 1f, spawnInterval);
    }

    void SpawnNote()
    {
        if (player == null) return;

        // FIX 1: Use the Player's Z position explicitly
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 10f, player.position.z);

        // FIX 2: Use 'notePrefab.transform.rotation' instead of 'Quaternion.identity'
        // This tells Unity: "Use the rotation I set in the Prefab, don't reset it to zero."
        Instantiate(notePrefab, spawnPos, notePrefab.transform.rotation);
    }
}
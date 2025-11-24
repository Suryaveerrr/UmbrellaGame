using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject[] notePrefabs;
    public Transform player;

    [Header("Settings")]
    public float spawnInterval = 0.6f; 
    public float laneDistance = 3f; 

    void Start()
    {
        InvokeRepeating("SpawnNote", 1f, spawnInterval);
    }

    void SpawnNote()
    {
        if (player == null || notePrefabs.Length == 0) return;

      
        GameObject selectedPrefab = notePrefabs[Random.Range(0, notePrefabs.Length)];

       
        int randomLaneIndex = Random.Range(0, 3);
        float spawnX = 0f;

        if (randomLaneIndex == 0) spawnX = -laneDistance;
        else if (randomLaneIndex == 1) spawnX = 0f;
        else if (randomLaneIndex == 2) spawnX = laneDistance;

        
        Vector3 spawnPos = new Vector3(spawnX, 10f, player.position.z);

        
        Instantiate(selectedPrefab, spawnPos, selectedPrefab.transform.rotation);
    }
}

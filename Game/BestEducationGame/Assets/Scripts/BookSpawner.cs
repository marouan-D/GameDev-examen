using UnityEngine;

public class BookSpawner : MonoBehaviour
{
    // Array met alle prefabs die gespawnd kunnen worden (Book, Meteor, ...)
    public GameObject[] fallingObjectPrefabs;

    public float spawnInterval = 1.5f;
    public float spawnRangeX = 7f;
    public float spawnY = 6f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        // Kies willekeurig een prefab uit de lijst
        int index = Random.Range(0, fallingObjectPrefabs.Length);
        GameObject chosenPrefab = fallingObjectPrefabs[index];

        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        Instantiate(chosenPrefab, spawnPosition, Quaternion.identity);
    }
}
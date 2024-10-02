using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab; // Prefab pipa yang akan dipakai
    public float spawnInterval = 2f; // Interval waktu antar spawn pipa
    public float heightOffset = 3f; // Jarak antara pipa atas dan pipa bawah

    private void Start()
    {
        // Mulai Coroutine untuk spawn pipa
        StartCoroutine(SpawnPipes());
    }

    private IEnumerator SpawnPipes()
    {
        while (true)
        {
            // Menghasilkan pipa secara acak
            float randomY = Random.Range(-heightOffset, heightOffset);
            Vector3 spawnPosition = new Vector3(10f, randomY, 0); // Posisi spawn pipa

            // Spawn pipa
            Instantiate(pipePrefab, spawnPosition, Quaternion.identity);

            // Tunggu selama spawnInterval sebelum spawn pipa berikutnya
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

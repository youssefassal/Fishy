using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
  
    public GameObject[] fishPrefabs; 
    public float spawnInterval = 2f;
    private float timer;
    public float[] weights = { 0.6f, 0.4f, 0.2f, 0.08f};

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnFish();
            timer = 0;
        }
    }

    void SpawnFish()
    {
    
        if (weights.Length != fishPrefabs.Length)
        { 
            return;
        }
        float totalWeight = 0f;
        foreach (float weight in weights)
        {
            totalWeight += weight;
        }
        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0f;
        for (int i = 0; i < weights.Length; i++)
        {
            cumulativeWeight += weights[i];
            if (randomValue <= cumulativeWeight)
            {
                Instantiate(fishPrefabs[i]);
                break;
            }
        }
    }
}

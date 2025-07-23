using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinspawmer : MonoBehaviour
{
    public GameObject coinPrefab; // Assign the coin prefab
    public int numberOfCoins = 20; // Total number of coins to spawn
    public float levelWidth = 3f; // Horizontal range for coins
    public float minY = 0.5f; // Minimum vertical gap between coins
    public float maxY = 2f; // Maximum vertical gap between coins
    public float minXGap = 1.5f; // Minimum horizontal gap between coins

    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfCoins; i++)
        {
            // Increment the Y position by a random vertical gap
            spawnPosition.y += Random.Range(minY, maxY);

            // Generate a valid X position with a minimum gap
            float randomX = Random.Range(-levelWidth, levelWidth);

            // Ensure the new X position is outside the minimum gap from the previous position
            while (Mathf.Abs(randomX - spawnPosition.x) < minXGap)
            {
                randomX = Random.Range(-levelWidth, levelWidth);
            }
            spawnPosition.x = randomX;

            // Instantiate the coin at the calculated position
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
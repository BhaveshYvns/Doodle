using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LevelGenartor : MonoBehaviour
{
    public GameObject platPrefab;   // Platform prefab reference
    public GameObject coinPrefab;   // Coin prefab reference

    public int numberOfPlatforms;   // Number of platforms to spawn
  //  public int numberOfCoins;
    public float levelWidth = 3f;   // Width of the level (X-axis)
    public float minY = .2f;       // Minimum Y offset for vertical platform placement
    public float maxY = 3f;        // Maximum Y offset for vertical platform placement

    public float minXGap = 1.5f;   // Minimum horizontal gap between platforms

    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            // Randomize the X position while staying within levelWidth
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);

            // Increment the Y position by a random vertical gap
            spawnPosition.y += Random.Range(minY, maxY);

            // Instantiate the platform at the new position
            GameObject platform = Instantiate(platPrefab, spawnPosition, Quaternion.identity);

            // Spawn a coin on top of the platform
            SpawnCoin(platform.transform);
        }
    }

    // Method to spawn a coin on top of the platform
    void SpawnCoin(Transform platformTransform)
    {
        // Get the position on top of the platform (just above the platform's Y position)
        Vector3 coinPosition = platformTransform.position;

        // Randomize the X position of the coin within the width of the platform
        coinPosition.x += Random.Range(-levelWidth / 3, levelWidth / 3);

        // Set the Y position just above the platform
        coinPosition.y += 1f;  // Adjust the height based on coin size and platform height

        Debug.Log("Coin spawning at position: " + coinPosition);

        // Instantiate the coin at the new position
        Instantiate(coinPrefab, coinPosition, Quaternion.identity);
    }
}

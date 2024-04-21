//This program spawns cars at a set and then terminates them when they reach another point. New cars are spawned in time intervals. Code written with ChatGPT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    private GameObject[] carPrefabs; // Array of car prefabs loaded dynamically
    public float threshold = 0.9f; // Threshold to check if the car has reached the endpoint
    public int numberOfCars = 5; // Total number of cars to spawn
    public float spawnDelay = 2.0f; // Delay in seconds between spawns

    private List<GameObject> currentCars; // List to hold current car instances
    private const string PrefabFolderPath = "Vehicles For Spawn Points"; // Path within the Resources folder

    void Start()
    {
        currentCars = new List<GameObject>(); // Initialize the list
        LoadCarPrefabs();
        StartCoroutine(SpawnCarsWithDelay());
    }

    void Update()
    {
        for (int i = 0; i < currentCars.Count; i++)
        {
            if (currentCars[i] != null && Vector3.Distance(currentCars[i].transform.position, endPoint.position) < threshold)
            {
                Destroy(currentCars[i]); // Destroy the car when it's close enough to the endpoint
                currentCars.RemoveAt(i); // Remove the car from the list to keep the list clean
                i--; // Decrement the index to ensure the next car is checked properly after the list modification
            }
        }
    }

    IEnumerator SpawnCarsWithDelay()
    {
        for (int i = 0; i < numberOfCars; i++)
        {
            SpawnCarAtStartPoint();
            yield return new WaitForSeconds(spawnDelay); // Wait for the specified delay before spawning the next car
        }
    }

    void LoadCarPrefabs()
    {
        carPrefabs = Resources.LoadAll<GameObject>(PrefabFolderPath);
        if (carPrefabs == null || carPrefabs.Length == 0)
        {
            Debug.LogError("Failed to load car prefabs. Check folder path: " + PrefabFolderPath);
        }
    }

    void SpawnCarAtStartPoint()
    {
        if (carPrefabs != null && carPrefabs.Length > 0)
        {
            int index = Random.Range(0, carPrefabs.Length);
            GameObject newCar = Instantiate(carPrefabs[index], startPoint.position, startPoint.rotation);
            currentCars.Add(newCar); // Add the new car to the list
        }
        else
        {
            Debug.LogError("No car prefabs loaded.");
        }
    }
}
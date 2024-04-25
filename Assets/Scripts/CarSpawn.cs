//This program spawns cars at a set point and  terminates them when they reach another point. New cars are spawned in time intervals. Code written with ChatGPT

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CarSpawn : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    private GameObject[] carPrefabs; // Array of car prefabs loaded dynamically
    public float threshold = 0.9f; // Threshold to check if the car has reached the endpoint
    public float spawnDelay = 2.0f; // Delay in seconds between spawns
    public string assetLabel = "Cars"; // Label used to load assets

    private List<GameObject> currentCars; // List to hold current car instances
    private bool prefabsLoaded = false; // Flag to check if prefabs are loaded

    void Start()
    {
        currentCars = new List<GameObject>(); // Initialize the list
        LoadCarPrefabs(); // Load car prefabs using Addressables
    }

    void Update()
    {
        if (!prefabsLoaded)
            return;

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
        // Infinite loop to continuously spawn cars
        while (true)
        {
            SpawnCarAtStartPoint();
            yield return new WaitForSeconds(spawnDelay); // Wait for the specified delay before spawning the next car
        }
    }

    void LoadCarPrefabs()
    {
        Addressables.LoadAssetsAsync<GameObject>(assetLabel, null).Completed += OnCarPrefabsLoaded;
    }

    private void OnCarPrefabsLoaded(AsyncOperationHandle<IList<GameObject>> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            carPrefabs = new GameObject[handle.Result.Count];
            handle.Result.CopyTo(carPrefabs, 0);
            prefabsLoaded = true;
            StartCoroutine(SpawnCarsWithDelay()); // Start spawning only after prefabs are loaded
            Debug.Log("Car prefabs loaded successfully.");
        }
        else
        {
            Debug.LogError("Failed to load car prefabs using label: " + assetLabel);
        }
    }

    void SpawnCarAtStartPoint()
    {
        if (carPrefabs != null && carPrefabs.Length > 0)
        {
            int index = Random.Range(0, carPrefabs.Length);
            Vector3 direction = (endPoint.position - startPoint.position).normalized; // Get the direction vector towards the endpoint
            Quaternion rotation = Quaternion.LookRotation(direction); // Create a rotation that looks along the direction vector
            GameObject newCar = Instantiate(carPrefabs[index], startPoint.position, rotation); // Instantiate the car facing the endpoint
            currentCars.Add(newCar); // Add the new car to the list
        }
        else
        {
            Debug.LogError("No car prefabs loaded.");
        }
    }
}
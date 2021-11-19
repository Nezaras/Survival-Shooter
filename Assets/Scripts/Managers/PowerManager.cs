using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    public float spawnRadius = 4f;
    public float spawnTime = 6f;

    public GameObject[] PickupItems;
    public Transform[] pickupLocations;

    private Dictionary<Transform, GameObject> spawnedPickups;

    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        spawnedPickups = new Dictionary<Transform, GameObject>();
        SetupSpawner();

        playerHealth = FindObjectOfType<PlayerHealth>();

        InvokeRepeating("SpawnPickup", spawnTime, spawnTime);
    }
    void SetupSpawner()
    {
        foreach (Transform location in pickupLocations)
        {
            spawnedPickups.Add(location, null);
        }
    }

    Transform[] getVacantLocations()
    {
        List<Transform> result = new List<Transform>();
        foreach (Transform location in pickupLocations)
        {
            GameObject obj = spawnedPickups[location];
            if (obj == null || !obj.activeSelf)
            {
                spawnedPickups[location] = null;
                result.Add(location);
            }
        }
        return result.ToArray();
    }

    void SpawnPickup()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        Transform[] vacant = getVacantLocations();

        if (vacant.Length == 0)
        {
            return;
        }

        int pickupIndex = Random.Range(0, PickupItems.Length);
        int locationIndex = Random.Range(0, vacant.Length);

        Transform location = vacant[locationIndex];

        Vector3 randomPos = location.position;
        randomPos += new Vector3(Random.Range(0f, spawnRadius), 0, Random.Range(0f, spawnRadius));

        GameObject obj = Instantiate(PickupItems[pickupIndex], randomPos, Quaternion.identity);
        spawnedPickups[location] = obj;
    }
}

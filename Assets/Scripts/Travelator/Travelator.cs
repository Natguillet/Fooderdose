using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travelator : MonoBehaviour {

    [SerializeField] private float speedTravelator = 1f;
    [SerializeField] private GameObject food;
    private Transform spawnPoint;

    public float SpeedTravelator
    {
        get
        {
            return speedTravelator;
        }

        set
        {
            speedTravelator = value;
        }
    }

    // Use this for initialization
    void Start () {
        spawnPoint = GetComponentInChildren<Transform>();
        InvokeRepeating("Spawn", 1/speedTravelator, 1/speedTravelator);
    }

    void Spawn()
    {
        // Create an instance of the food prefab at the spawn point's position and rotation.
        GameObject newFood = Instantiate(food, spawnPoint.position, spawnPoint.rotation);
        newFood.transform.parent = gameObject.transform;
    }
}

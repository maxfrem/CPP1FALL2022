using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] pickups;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pickups[0], transform.position, transform.rotation);
    }
}